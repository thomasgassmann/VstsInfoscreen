namespace VSTSInfoscreen.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.TeamFoundation.Build.WebApi;

    /// <summary>
    /// Defines the build view model.
    /// </summary>
    public class BuildViewModel
    {
        /// <summary>
        /// Gets or sets the id of the build.
        /// </summary>
        public int BuildId { get; set; }

        /// <summary>
        /// Gets or sets the build definition of the build.
        /// </summary>
        public string BuildDefinition { get; set; }

        /// <summary>
        /// Gets or sets the commit text of the build.
        /// </summary>
        public string SourceVersionCommit { get; set; }

        /// <summary>
        /// Gets or sets the source branch of the build.
        /// </summary>
        public string SourceBranch { get; set; }

        /// <summary>
        /// Gets or sets the name of the user, who requested the build.
        /// </summary>
        public string RequestedBy { get; set; }

        /// <summary>
        /// Gets or sets the URL of the profile picture of the user, who requested the build.
        /// </summary>
        public string RequestedByProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the date indicating when the build was queued.
        /// </summary>
        public DateTime Queued { get; set; }

        /// <summary>
        /// Gets or sets the position in the build queue.
        /// </summary>
        public int QueueCount { get; set; }

        /// <summary>
        /// Gets or sets a date indicating when the build was started.
        /// </summary>
        public DateTime Started { get; set; }

        /// <summary>
        /// Gets or sets the finished date of the build.
        /// </summary>
        public DateTime Finished { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the build succeeded.
        /// </summary>
        public bool BuildSucceeded { get; set; }

        /// <summary>
        /// Gets or sets the status of the build.
        /// </summary>
        public BuildStatus BuildStatus { get; set; }

        /// <summary>
        /// Gets or sets the result of the build.
        /// </summary>
        public BuildResult BuildResult { get; set; }

        /// <summary>
        /// Gets or sets the time line of the build.
        /// </summary>
        public IEnumerable<BuildTimeLineElementViewModel> Timeline { get; set; }

        /// <summary>
        /// Gets all worker names active while building.
        /// </summary>
        public string WorkerNames
        {
            get
            {
                return string.Join(", ", this.Timeline.Select(x => x.WorkerName).Distinct());
            }
        }
    }
}