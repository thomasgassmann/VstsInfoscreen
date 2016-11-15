namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the inputs.
    /// </summary>
    public class Inputs
    {
        /// <summary>
        /// Gets or sets the add in file.
        /// </summary>
        [JsonProperty(PropertyName = "AddInFile")]
        public string AddInFile { get; set; }

        /// <summary>
        /// Gets or sets the url of the input.
        /// </summary>
        [JsonProperty(PropertyName = "Url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the client id.
        /// </summary>
        [JsonProperty(PropertyName = "ClientId")]
        public string ClientId { get; set; }
    }
}