namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a reference to a release definition.
    /// </summary>
    public class DefinitionRef
    {
        /// <summary>
        /// Gets or sets the artifacts of the release definitions.
        /// </summary>
        [JsonProperty(PropertyName = "artifacts")]
        public NameId Artifacts { get; set; }

        /// <summary>
        /// Gets or sets the artifact source definition url.
        /// </summary>
        [JsonProperty(PropertyName = "artifactSourceDefinitionUrl")]
        public NameId ArtifactSourceDefinitionUrl { get; set; }

        /// <summary>
        /// Gets or sets the definition.
        /// </summary>
        [JsonProperty(PropertyName = "definition")]
        public NameId Definition { get; set; }

        /// <summary>
        /// Gets or sets the project.
        /// </summary>
        [JsonProperty(PropertyName = "project")]
        public NameId Project { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public NameId Version { get; set; }

        /// <summary>
        /// Gets or sets the branch.
        /// </summary>
        [JsonProperty(PropertyName = "branch")]
        public NameId Branch { get; set; }

        /// <summary>
        /// Gets or sets the artifact source version url.
        /// </summary>
        [JsonProperty(PropertyName = "artifactSourceVersionUrl")]
        public NameId ArtifactSourceVersionUrl { get; set; }
    }
}