namespace VSTSInfoscreen.Models
{
    using System;

    /// <summary>
    /// Defines the view model for the pull request.
    /// </summary>
    public class PullRequestViewModel
    {
        /// <summary>
        /// Gets or sets the id of the pull request.
        /// </summary>
        public int PullRequestId { get; set; }

        /// <summary>
        /// Gets or sets the user name of the user, who created the build.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the profiel picture URL of the user, who created the build.
        /// </summary>
        public string CreatedByProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the repository name.
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the title of the pull request.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the merge status of the pull request.
        /// </summary>
        public string MergeStatus { get; set; }

        /// <summary>
        /// Gets or sets the source branch of the pull request.
        /// </summary>
        public string SourceBranch { get; set; }

        /// <summary>
        /// Gets or sets the destination branch of the pull request.
        /// </summary>
        public string DestinationBranch { get; set; }

        /// <summary>
        /// Gets or sets a date, indicating when the pull request was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the associated build of the pull request succeeded or not. If the value is null, the build is currently running.
        /// </summary>
        public bool? BuildSucceeded { get; set; }
    }
}