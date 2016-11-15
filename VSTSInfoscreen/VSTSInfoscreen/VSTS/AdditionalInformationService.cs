namespace VSTSInfoscreen.VSTS
{
    using Microsoft.TeamFoundation.Build.WebApi;
    using Microsoft.TeamFoundation.SourceControl.WebApi;
    using Microsoft.TeamFoundation.Work.WebApi;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the service to get the additional information.
    /// </summary>
    public class AdditionalInformationService : VstsService
    {
        /// <summary>
        /// Contains all iterations.
        /// </summary>
        private readonly List<WorkItemClassificationNode> iterations = new List<WorkItemClassificationNode>();

        /// <summary>
        /// Contains the workitemtracking http client.
        /// </summary>
        private readonly Lazy<WorkItemTrackingHttpClient> witClient;

        /// <summary>
        /// Contains the value when the iterations were last updated.
        /// </summary>
        private DateTime lastUpdatedIterations = DateTime.Now;

        /// <summary>
        /// The build client.
        /// </summary>
        private readonly Lazy<BuildHttpClient> buildClient;

        /// <summary>
        /// The git client.
        /// </summary>
        private readonly Lazy<GitHttpClient> gitClient;

        /// <summary>
        /// The release service.
        /// </summary>
        private readonly Lazy<ReleaseService> releaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalInformationService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration for the <see cref="AdditionalInformationService"/>.</param>
        public AdditionalInformationService(InfoscreenConfiguration configuration) : 
            base(configuration)
        {
            this.witClient = new Lazy<WorkItemTrackingHttpClient>(() => this.GetWorkItemTrackingHttpClient());
            this.buildClient = new Lazy<BuildHttpClient>(() => this.GetBuildClient());
            this.gitClient = new Lazy<GitHttpClient>(() => this.GetGitClient());
            this.releaseService = new Lazy<ReleaseService>(() => new ReleaseService(configuration));
        }

        /// <summary>
        /// Gets all iterations.
        /// </summary>
        protected IEnumerable<WorkItemClassificationNode> Iterations
        {
            get
            {
                if (this.iterations.Count < 1 ||
                    (DateTime.Now - this.lastUpdatedIterations).TotalHours > this.Configuration.UpdateIterationsHour)
                {
                    lastUpdatedIterations = DateTime.Now;
                    this.iterations.Clear();
                    var allIterations = this.WitClient.GetClassificationNodeAsync(
                        this.Configuration.TeamProject,
                        TreeStructureGroup.Iterations,
                        string.Empty,
                        100).Result;
                    this.iterations.Add(allIterations);
                    if (allIterations.Children != null)
                    {
                        foreach (var item in allIterations.Children)
                        {
                            this.iterations.Add(item);
                            this.GetAllNodes(item);
                        }
                    }
                }

                return this.iterations;
            }
        }

        /// <summary>
        /// Gets the work item tracking http client.
        /// </summary>
        public WorkItemTrackingHttpClient WitClient => this.witClient.Value;

        /// <summary>
        /// Gets the build client.
        /// </summary>
        public BuildHttpClient BuildClient => this.buildClient.Value;

        /// <summary>
        /// Gets the git client.
        /// </summary>
        public GitHttpClient GitClient => this.gitClient.Value;

        /// <summary>
        /// Gets the release service.
        /// </summary>
        protected ReleaseService ReleaseService => this.releaseService.Value;

        /// <summary>
        /// Gets all additional information view models.
        /// </summary>
        /// <returns>Returns the view models.</returns>
        public IEnumerable<AdditionalInformationViewModel> GetAdditionalInformationViewModels()
        {
            var additionalInformation = new List<AdditionalInformationViewModel>();
            if (this.Configuration.AdditionalInformation.DaysOffAndCapacityPerPerson)
            {
                additionalInformation.AddRange(this.GetCapacities());
            }

            if (this.Configuration.AdditionalInformation.CurrentIteration)
            {
                var iteration = this.GetCurrentIteration();
                if (iteration != null)
                {
                    additionalInformation.Add(new AdditionalInformationViewModel(
                        "Current iteration",
                        iteration.Name));
                }
            }

            if (this.Configuration.AdditionalInformation.FailedBuildsLast7Days)
            {
                additionalInformation.Add(new AdditionalInformationViewModel(
                    "Failed builds last 7 days",
                    this.BuildClient.GetBuildsAsync(
                        this.Configuration.TeamProject,
                        minFinishTime: DateTime.Now - TimeSpan.FromDays(7),
                        maxFinishTime: DateTime.Now,
                        resultFilter: BuildResult.Failed).Result.Count.ToString()));
            }

            if (this.Configuration.AdditionalInformation.SuccessfulBuildsLast7Days)
            {
                additionalInformation.Add(new AdditionalInformationViewModel(
                    "Successful builds last 7 days",
                    this.BuildClient.GetBuildsAsync(
                        this.Configuration.TeamProject,
                        minFinishTime: DateTime.Now - TimeSpan.FromDays(7),
                        maxFinishTime: DateTime.Now,
                        top: 5000,
                        resultFilter: BuildResult.Succeeded).Result.Count.ToString()));
            }

            if (this.Configuration.AdditionalInformation.OpenPullRequests)
            {
                additionalInformation.Add(new AdditionalInformationViewModel(
                    "Open Pull Requests",
                    this.GitClient.GetPullRequestsByProjectAsync(
                        this.Configuration.TeamProject,
                        new GitPullRequestSearchCriteria { Status = PullRequestStatus.Active }).Result.Count.ToString()));
            }

            if (this.Configuration.AdditionalInformation.PullRequestsWithMergeConflicts)
            {
                additionalInformation.Add(new AdditionalInformationViewModel(
                    "Merge conflicts",
                    this.GitClient.GetPullRequestsByProjectAsync(
                        this.Configuration.TeamProject,
                        new GitPullRequestSearchCriteria()).Result
                            .Count(x => x.MergeStatus == PullRequestAsyncStatus.Conflicts).ToString()));
            }

            if (this.Configuration.AdditionalInformation.NewWorkItemCount)
            {
                additionalInformation.Add(new AdditionalInformationViewModel(
                    "New work items",
                    this.WitClient.QueryByWiqlAsync(new Wiql { Query = "SELECT [System.ID] from workitems where [State] = 'New'" }).Result.WorkItems.Count().ToString()));
            }

            if (this.Configuration.AdditionalInformation.TeamDaysOff)
            {
                var off = this.GetDaysOff();
                if (off != null)
                {
                    additionalInformation.Add(new AdditionalInformationViewModel(
                        "Team days off",
                        off));
                }
            }

            if (this.Configuration.AdditionalInformation.SuccessfulReleasesLast7Days)
            {
                var count = this.ReleaseService.QueryReleases().Where(x =>
                    x.CreatedOn > (DateTime.Now - TimeSpan.FromDays(7)))
                        .SelectMany(x => x.Environments).Count(x => x.Status == "succeeded");
                additionalInformation.Add(new AdditionalInformationViewModel(
                    "Successful releases last 7 days",
                    count.ToString()));
            }

            if (this.Configuration.AdditionalInformation.FailedReleasesLast7Days)
            {
                var count = this.ReleaseService.QueryReleases().Where(x =>
                    x.CreatedOn > (DateTime.Now - TimeSpan.FromDays(7)))
                        .SelectMany(x => x.Environments).Count(x => x.Status == "failed");
                additionalInformation.Add(new AdditionalInformationViewModel(
                    "Failed releases last 7 days",
                    count.ToString()));
            }

            if (this.Configuration.AdditionalInformation.CompletedPullRequestsLast7Days)
            {
                var count = this.GitClient.GetPullRequestsByProjectAsync(
                    this.Configuration.TeamProject,
                    new GitPullRequestSearchCriteria { Status = PullRequestStatus.Completed },
                    top: 5000).Result.Count(x => x.ClosedDate > (DateTime.Now - TimeSpan.FromDays(7)));
                additionalInformation.Add(new AdditionalInformationViewModel(
                    "Completed pull requests last 7 days",
                    count.ToString()));
            }

            return additionalInformation;
        }

        /// <summary>
        /// Gets the current iteration.
        /// </summary>
        /// <returns>Returns the current iteration.</returns>
        private WorkItemClassificationNode GetCurrentIteration()
        {
            return this.Iterations.FirstOrDefault(x =>
            {
                var start = x?.Attributes?["startDate"] + string.Empty;
                var end = x?.Attributes?["finishDate"] + string.Empty;
                if (string.IsNullOrEmpty(start) || string.IsNullOrEmpty(end))
                {
                    return false;
                }

                return DateTime.Parse(start).DayOfYear <= DateTime.Now.DayOfYear &&
                    DateTime.Parse(end).DayOfYear >= DateTime.Now.DayOfYear &&
                    x?.Children == null;
            });
        }

        /// <summary>
        /// Gets all days off of the team.
        /// </summary>
        /// <returns>Returns the days off.</returns>
        private string GetDaysOff()
        {
            try
            {
                var iteration = this.GetCurrentIteration();
                var jsonContent = this.GetJson(
                    $"/work/teamsettings/iterations/{iteration.Identifier}/teamdaysoff");
                var daysOff = JObject.Parse(jsonContent);
                var daysOffList = new List<string>();
                daysOff["daysOff"].Children().ToList().ForEach(x =>
                {
                    var start = DateTime.Parse(x["start"].ToString()).ToString("dd.MM");
                    var end = DateTime.Parse(x["end"].ToString()).ToString("dd.MM");
                    daysOffList.Add($"{start} - {end}");
                });
                if (!daysOffList.Any())
                {
                    return null;
                }

                return string.Join(", ", daysOffList);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all capacities of the team.
        /// </summary>
        /// <returns>Returns the capacities foreach team member.</returns>
        private IEnumerable<AdditionalInformationViewModel> GetCapacities()
        {
            var iteration = this.GetCurrentIteration();
            var jsonContent = this.GetJson(
                $"/work/teamsettings/iterations/{iteration.Identifier}/capacities");
            var capacities = JObject.Parse(jsonContent)["value"].Children().Select(x => x.ToString());
            foreach (var capacity in capacities)
            {
                var c = JsonConvert.DeserializeObject<TeamMemberCapacity>(capacity);
                yield return new AdditionalInformationViewModel(
                    $"{c.TeamMember.DisplayName.Substring(0, c.TeamMember.DisplayName.IndexOf("<"))}",
                    $"{c.DaysOff.Aggregate(TimeSpan.FromDays(0), (current, range) => current + (range.End - range.Start)).TotalDays}d off, {c.Activities.Average(x => x.CapacityPerDay)}h/day");
            }
        }

        /// <summary>
        /// Gets all nodes of a <see cref="WorkItemClassificationNode"/> recursively.
        /// </summary>
        /// <param name="root">The root node.</param>
        private void GetAllNodes(WorkItemClassificationNode root)
        {
            if (root.Children != null)
            {
                foreach (var child in root.Children)
                {
                    this.iterations.Add(child);
                    this.GetAllNodes(child);
                }
            }
        }

        /// <summary>
        /// Gets a new work item tracking http client.
        /// </summary>
        /// <returns>Return the newly created client.</returns>
        private WorkItemTrackingHttpClient GetWorkItemTrackingHttpClient() =>
            new WorkItemTrackingHttpClient(this.Configuration.BaseUri, this.Configuration.Credential);
    }
}