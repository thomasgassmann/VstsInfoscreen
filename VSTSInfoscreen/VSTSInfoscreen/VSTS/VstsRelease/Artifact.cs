namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a release artifact.
    /// </summary>
    public class Artifact
    {
        /// <summary>
        /// Gets or sets the release source id.
        /// </summary>
        [JsonProperty(PropertyName = "sourceId")]
        public string SourceId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the release defintion reference.
        /// </summary>
        [JsonProperty(PropertyName = "definitionReference")]
        public DefinitionRef DefinitionReference { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the artifact is primary.
        /// </summary>
        [JsonProperty(PropertyName = "isPrimary")]
        public bool IsPrimary { get; set; }
    }
}