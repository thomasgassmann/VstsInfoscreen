namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// An id name class.
    /// </summary>
    public class NameId
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}