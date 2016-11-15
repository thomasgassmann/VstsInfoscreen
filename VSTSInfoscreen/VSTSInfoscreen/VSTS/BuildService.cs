namespace VSTSInfoscreen.VSTS
{
    using Microsoft.TeamFoundation.Build.WebApi;
    using Microsoft.TeamFoundation.SourceControl.WebApi;
    using Microsoft.VisualStudio.Services.WebApi;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the build service to get the builds from Visual Studio Team Services.
    /// </summary>
    public class BuildService : VstsService
    {
        /// <summary>
        /// Contains the date when the build definitions were last updated.
        /// </summary>
        private DateTime lastUpdatedDefinitions = DateTime.Now;

        /// <summary>
        /// Contains all ids of all build definitions.
        /// </summary>
        private readonly List<int> definitions = new List<int>();

        /// <summary>
        /// Contains the build http client.
        /// </summary>
        private readonly Lazy<BuildHttpClient> buildClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildService"/> class.
        /// </summary>
        /// <param name="config">The <see cref="InfoscreenConfiguration"/> configuration.</param>
        public BuildService(InfoscreenConfiguration config) : 
            base(config)
        {
            this.buildClient = new Lazy<BuildHttpClient>(() => this.GetBuildClient());
        }

        /// <summary>
        /// Gets the build http client.
        /// </summary>
        public BuildHttpClient BuildClient => this.buildClient.Value;
        
        /// <summary>
        /// Gets all build definitions.
        /// </summary>
        public IEnumerable<int> Definitions
        {
            get
            {
                if (this.definitions.Count < 1 ||
                    (DateTime.Now - this.lastUpdatedDefinitions).TotalHours > this.Configuration.UpdateIterationsHour)
                {
                    this.definitions.Clear();
                    this.lastUpdatedDefinitions = DateTime.Now;
                    this.BuildClient
                        .GetDefinitionsAsync(project: this.Configuration.TeamProject, top: 5000)
                        .Result
                        .Select(x => x.Id)
                        .ToList()
                        .ForEach(this.definitions.Add);
                }

                return this.definitions;
            }
        }

        /// <summary>
        /// Gets all build view models.
        /// </summary>
        /// <returns>Returns the build view models.</returns>
        public IEnumerable<BuildViewModel> GetBuildViewModels()
        {
            var builds = this.QueryBuilds();
            foreach (var build in builds)
            {
                var model = new BuildViewModel
                {
                    BuildDefinition = build.Definition.Name,
                    BuildId = build.Id,
                    BuildStatus = build.Status.HasValue ? build.Status.Value : BuildStatus.None,
                    BuildResult = build.Result.GetValueOrDefault(BuildResult.None),
                    Finished = build.FinishTime.GetValueOrDefault(DateTime.Now).ToLocalTime(),
                    QueueCount = build.QueuePosition.GetValueOrDefault(0),
                    Queued = build.QueueTime.GetValueOrDefault(DateTime.Now),
                    RequestedBy = build.RequestedBy.DisplayName,
                    RequestedByProfilePicture = build.RequestedBy.GetProfilePath(),
                    SourceBranch = build.SourceBranch,
                    SourceVersionCommit = this.GetCommitText(build.SourceVersion, build.Repository.Id),
                    Started = build.StartTime.GetValueOrDefault(DateTime.Now).ToLocalTime(),
                    Timeline = !this.Configuration.CompactMode ? this.GetTimeline(build) : Enumerable.Empty<BuildTimeLineElementViewModel>()
                };
                yield return model;
            }
        }

        /// <summary>
        /// Gets the commit text.
        /// </summary>
        /// <param name="commitId">The commit id.</param>
        /// <param name="repositoryId">The repository id.</param>
        /// <returns>Retuns the comment of the commit.</returns>
        private string GetCommitText(string commitId, string repositoryId) =>
             this.ExecuteRestRequest<GitCommit>(
                $"git/repositories/{repositoryId}/commits/{commitId}").Comment;

        /// <summary>
        /// Gets the timeline of a build.
        /// </summary>
        /// <param name="build">The build to get the timeline from.</param>
        /// <returns>Returns the timeline.</returns>
        private IEnumerable<BuildTimeLineElementViewModel> GetTimeline(Build build)
        {
            var timelineUrl = (ReferenceLink)build.Links.Links["timeline"];
            var content = this.GetJson(timelineUrl.Href.Substring(build.Logs.Url.IndexOf("/_apis/") + 7));
            var timeline = JObject.Parse(content);
            var results = timeline["records"].Children().ToList();
            var timelineList = new List<TimelineRecord>();
            foreach (var item in results)
            {
                timelineList.Add(JsonConvert.DeserializeObject<TimelineRecord>(item.ToString()));
            }

            return timelineList.Select(x => 
                new BuildTimeLineElementViewModel
                {
                    Duration = (x.FinishTime - x.StartTime).GetValueOrDefault(new TimeSpan(0, 0, 0)).GetReadableTimeSpan(),
                    Name = x.Name,
                    Successful = x.Result == TaskResult.Succeeded,
                    WorkerName = x.WorkerName
                });
        }

        /// <summary>
        /// Queries all builds from the build http client.
        /// </summary>
        /// <returns>Returns all queried builds.</returns>
        private IEnumerable<Build> QueryBuilds()
        {
            var builds = new List<Build>();
            builds.AddRange(this.BuildClient.GetBuildsAsync(
                this.Configuration.TeamProject,
                definitions: this.Definitions,
                maxBuildsPerDefinition: 1,
                top: 5000,
                minFinishTime: DateTime.Now - this.Configuration.GetBuildsTimeFrameForSucceededBuilds,
                type: DefinitionType.Build).Result.Where(x => x.Status != BuildStatus.InProgress));
            builds.AddRange(this.BuildClient.GetBuildsAsync(
                    this.Configuration.TeamProject,
                    definitions: this.Definitions,
                    statusFilter: BuildStatus.InProgress).Result);
            return builds;
        }
    }
}