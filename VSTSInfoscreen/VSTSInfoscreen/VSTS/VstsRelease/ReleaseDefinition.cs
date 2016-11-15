namespace VSTSInfoscreen.VSTS
{
    using Microsoft.VisualStudio.Services.WebApi;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a release defintion.
    /// </summary>
    public class ReleaseDefinition
    {
        /// <summary>
        /// Gets or sets the id of the release definition.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the release definition.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the url of the release definition.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the reference links associated with the release definition.
        /// </summary>
        [JsonProperty(PropertyName = "_links")]
        public ReferenceLinks Links { get; set; }
    }
}