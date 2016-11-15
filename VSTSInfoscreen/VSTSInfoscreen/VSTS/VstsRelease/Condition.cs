namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a condition in the release API.
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Gets or sets the condition name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the condition type.
        /// </summary>
        [JsonProperty(PropertyName = "conditionType")]
        public string ConditionType { get; set; }

        /// <summary>
        /// Gets or sets the condition value.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}