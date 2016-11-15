namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines a reference to a project.
    /// </summary>
    public class ProjReference
    {
        /// <summary>
        /// Gets or sets the id of the project.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}