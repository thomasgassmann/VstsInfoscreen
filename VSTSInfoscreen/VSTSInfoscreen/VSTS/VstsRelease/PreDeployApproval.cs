namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Gets or sets the approval of a deploy.
    /// </summary>
    public class DeployApproval
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        [JsonProperty(PropertyName = "revision")]
        public int Revision { get; set; }

        /// <summary>
        /// Gets or sets the approval type.
        /// </summary>
        [JsonProperty(PropertyName = "approvalType")]
        public string ApprovalType { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the approval.
        /// </summary>
        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the modified date of the approval.
        /// </summary>
        [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the status of the build.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the comments of the build.
        /// </summary>
        [JsonProperty(PropertyName = "comments")]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pre deploy approval is automated.
        /// </summary>
        [JsonProperty(PropertyName = "isAutomated")]
        public bool IsAutomated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notifications are turned on.
        /// </summary>
        [JsonProperty(PropertyName = "isNotificationOn")]
        public bool IsNotificationOn { get; set; }

        /// <summary>
        /// Gets or sets the trial number.
        /// </summary>
        [JsonProperty(PropertyName = "trialNumber")]
        public int TrialNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of the current attempt.
        /// </summary>
        [JsonProperty(PropertyName = "attempt")]
        public int Attempt { get; set; }

        /// <summary>
        /// Gets or sets the current rank.
        /// </summary>
        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Gets or sets the relase reference.
        /// </summary>
        [JsonProperty(PropertyName = "release")]
        public ReleaseReference Release { get; set; }

        /// <summary>
        /// Gets or sets the release defintion.
        /// </summary>
        [JsonProperty(PropertyName = "releaseDefinition")]
        public ReleaseDefinition ReleaseDefinition { get; set; }

        /// <summary>
        /// Gets or sets the release environment to approve.
        /// </summary>
        [JsonProperty(PropertyName = "releaseEnvironment")]
        public ReleaseEnvironment ReleaseEnvironment { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}