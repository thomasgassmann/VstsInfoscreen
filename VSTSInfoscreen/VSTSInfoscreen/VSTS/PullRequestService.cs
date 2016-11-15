namespace VSTSInfoscreen.VSTS
{
    using Microsoft.TeamFoundation.SourceControl.WebApi;
    using Microsoft.VisualStudio.Services.WebApi;
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The pull request service used for getting the pull requests from Visual Studio Team Services.
    /// </summary>
    public class PullRequestService : VstsService
    {
        /// <summary>
        /// Contains the git client.
        /// </summary>
        private readonly Lazy<GitHttpClient> gitClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PullRequestService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public PullRequestService(InfoscreenConfiguration configuration) :
            base(configuration)
        {
            this.gitClient = new Lazy<GitHttpClient>(() => this.GetGitClient());
        }

        /// <summary>
        /// Gets the git client.
        /// </summary>
        public GitHttpClient GitClient => this.gitClient.Value;

        /// <summary>
        /// Gets all pull request view models to display.
        /// </summary>
        /// <returns>Returns the pull request view models.</returns>
        public IEnumerable<PullRequestViewModel> GetPullRequestViewModels()
        {
            var pullRequests = this.QueryPullRequests();
            var list = new List<PullRequestViewModel>();
            foreach (var pullRequest in pullRequests)
            {
                var pr = new PullRequestViewModel
                {
                    Created = pullRequest.CreationDate.ToLocalTime(),
                    CreatedBy = pullRequest.CreatedBy.DisplayName,
                    CreatedByProfilePicture = pullRequest.CreatedBy.GetProfilePath(),
                    DestinationBranch = pullRequest.TargetRefName,
                    PullRequestId = pullRequest.PullRequestId,
                    MergeStatus = pullRequest.MergeStatus.ToString(),
                    Repository = pullRequest.Repository.Name,
                    SourceBranch = pullRequest.SourceRefName,
                    Title = pullRequest.Title,
                    BuildSucceeded = pullRequest.MergeStatus == PullRequestAsyncStatus.Succeeded,
                };
                list.Add(pr);
            }

            return list;
        }
        
        /// <summary>
        /// Queries all pull requests.
        /// </summary>
        /// <returns>Returns the pull requests</returns>
        private IEnumerable<GitPullRequest> QueryPullRequests()
        {
            return this.GitClient.GetPullRequestsByProjectAsync(
                this.Configuration.TeamProject,
                new GitPullRequestSearchCriteria { Status = PullRequestStatus.Active }).Result;
        }
    }
}