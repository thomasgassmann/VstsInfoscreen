namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the deployment input in the release API.
    /// </summary>
    public class DeploymentInput
    {
        /// <summary>
        /// Gets or sets the id in the release queue.
        /// </summary>
        [JsonProperty(PropertyName = "queueId")]
        public int QueueId { get; set; }

        /// <summary>
        /// Gets or sets all demands.
        /// </summary>
        [JsonProperty(PropertyName = "demands")]
        public string[] Demands { get; set; }

        /// <summary>
        /// Gets or sets the timeout of the release in minutes.
        /// </summary>
        [JsonProperty(PropertyName = "timeoutInMinutes")]
        public int TimeoutInMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to skip the artifact downloads or not.
        /// </summary>
        [JsonProperty(PropertyName = "skipArtifactsDownload")]
        public bool SkipArtifactsDownload { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to accept a access token for authentication.
        /// </summary>
        [JsonProperty(PropertyName = "enableAccessToken")]
        public bool EnableAccessToken { get; set; }
        
        /// <summary>
        /// Gets or sets the parallel execution.
        /// </summary>
        [JsonProperty(PropertyName = "parallelExecution")]
        public ParallelExecution ParallelExecution { get; set; }
    }
}