namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the options of the environment.
    /// </summary>
    public class EnvironmentOptions
    {
        /// <summary>
        /// Gets or sets the email notification type.
        /// </summary>
        [JsonProperty(PropertyName = "emailNotificationType")]
        public string EMailNotificationType { get; set; }

        /// <summary>
        /// Gets or sets all recipients of the email.
        /// </summary>
        [JsonProperty(PropertyName = "emailRecipients")]
        public string EMailRecipients { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to skip the artifacts download.
        /// </summary>
        [JsonProperty(PropertyName = "skipArtifactsDownload")]
        public bool SkipArtifactsDownload { get; set; }

        /// <summary>
        /// Gets or sets the timeout in minutes.
        /// </summary>
        [JsonProperty(PropertyName = "timeoutInMinutes")]
        public int TimeoutInMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the access token for authentication.
        /// </summary>
        [JsonProperty(PropertyName = "enableAccessToken")]
        public bool EnableAccessToken { get; set; }
    }
}