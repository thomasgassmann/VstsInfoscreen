namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the approval model for the release API.
    /// </summary>
    public class Approval
    {
        /// <summary>
        /// Get or sets the rank.
        /// </summary>
        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the approval is automated.
        /// </summary>
        [JsonProperty(PropertyName = "isAutomated")]
        public bool IsAutomated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notifications are turned on.
        /// </summary>
        [JsonProperty(PropertyName = "isNotificationOn")]
        public bool IsNotificationOn { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}