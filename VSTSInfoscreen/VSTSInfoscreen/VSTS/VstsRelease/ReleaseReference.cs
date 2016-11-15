namespace VSTSInfoscreen.VSTS
{
    using Microsoft.VisualStudio.Services.WebApi;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a reference to a release.
    /// </summary>
    public class ReleaseReference
    {
        /// <summary>
        /// Gets or sets the release id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the release name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the url of the release.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the reference links associated with the release reference.
        /// </summary>
        [JsonProperty(PropertyName = "_links")]
        public ReferenceLinks Links { get; set; }
    }
}