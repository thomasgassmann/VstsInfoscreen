namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the release task.
    /// </summary>
    public class ReleaseTask : Job
    {
        /// <summary>
        /// Gets or sets the log url.
        /// </summary>
        [JsonProperty(PropertyName = "logUrl")]
        public string LogUrl { get; set; }
    }
}