namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a deployment job in the release API.
    /// </summary>
    public class DeploymentJob
    {
        /// <summary>
        /// Gets or sets the deployment job to execute.
        /// </summary>
        [JsonProperty(PropertyName = "job")]
        public Job Job { get; set; }

        /// <summary>
        /// Gets or sets all tasks associated with the deployment job.
        /// </summary>
        [JsonProperty(PropertyName = "tasks")]
        public ReleaseTask[] Tasks { get; set; }
    }
}