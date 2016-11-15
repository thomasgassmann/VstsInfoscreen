namespace VSTSInfoscreen.VSTS
{
    using Microsoft.VisualStudio.Services.WebApi;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the release service to get the releases.
    /// </summary>
    public class ReleaseService : VstsService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReleaseService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ReleaseService(InfoscreenConfiguration configuration) : 
            base(configuration)
        {
        }

        /// <summary>
        /// Gets all release view models.
        /// </summary>
        /// <returns>The release view models.</returns>
        public IEnumerable<ReleaseViewModel> GetReleaseViewModels()
        {
            var releases = this.QueryReleases();
            var list = new List<ReleaseViewModel>();
            foreach (var release in releases)
            {
                list.Add(new ReleaseViewModel
                {
                    Branch = release.Artifacts.FirstOrDefault()?.DefinitionReference?.Branch?.Name,
                    Created = release.CreatedOn,
                    Description = release.Description,
                    Reason = release.Reason,
                    ReleasedBy = release.CreatedBy.DisplayName,
                    ReleasedByProfilePicture = release.CreatedBy.GetProfilePath(),
                    ReleaseDefinitionName = release.ReleaseDefinition.Name,
                    ReleaseId = release.Id,
                    Succeeded = release.Environments
                        .SelectMany(x => x.DeploySteps)
                        .SelectMany(x => x.Tasks)
                        .Select(x => x.Status).All(x => x == "succeeded"),
                    IsInProgress = release.Status == "inprogress",
                    Status = release.Status,
                    Environments = release.Environments.Select(x =>
                    {
                        return new ReleaseEnvironmentViewModel
                        {
                            DeploymentStatus = x.Status,
                            Name = x.Name
                        };
                    })
                });
            }

            return list.Where(x => x.Created > (DateTime.Now - this.Configuration.GetReleasesTimeFrameForSucceededReleases) ||
                x.IsInProgress || !x.Succeeded);
        }
       
        /// <summary>
        /// Queries all releases.
        /// </summary>
        /// <returns>Returns the releases.</returns>
        public IEnumerable<Release> QueryReleases()
        {
            var json = this.GetJsonContent(
                this.Configuration.ApiBaseUri,
                "/_apis/release/releases?api-version=3.0-preview.2&$top=5000&queryOrder=descending");
            var releases = JObject.Parse(json);
            var releaseValues = releases["value"].Children().ToList();
            var list = new List<Release>();
            foreach (var release in releaseValues)
            {
                var releaseUri = release["url"].ToString();
                var releaseModel = this.ExecuteRestRequest<Release>(releaseUri);
                list.Add(releaseModel);
            }

            return list;
        }
    }
}