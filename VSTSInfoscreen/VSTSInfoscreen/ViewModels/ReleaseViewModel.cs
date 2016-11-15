namespace VSTSInfoscreen.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the release view model.
    /// </summary>
    public class ReleaseViewModel
    {
        /// <summary>
        /// Gets or sets the id of the release.
        /// </summary>
        public int ReleaseId { get; set; }

        /// <summary>
        /// Gets or sets the name of the release defintion.
        /// </summary>
        public string ReleaseDefinitionName { get; set; }

        /// <summary>
        /// Gets or sets the branch to release.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the build succeeded.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the release is in progress.
        /// </summary>
        public bool IsInProgress { get; set; }

        /// <summary>
        /// Gets or sets the status of the release.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the name of the user, who started the release.
        /// </summary>
        public string ReleasedBy { get; set; }

        /// <summary>
        /// Gets or sets the profile picture of the user, who started the release.
        /// </summary>
        public string ReleasedByProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets a date indicating when the release was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the description of the build.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the reason, because of which the release was started by the user.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the environments of the release.
        /// </summary>
        public IEnumerable<ReleaseEnvironmentViewModel> Environments { get; set; }
    }
}