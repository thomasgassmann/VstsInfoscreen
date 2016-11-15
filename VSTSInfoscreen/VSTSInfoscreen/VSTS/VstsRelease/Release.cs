namespace VSTSInfoscreen.VSTS
{
    using Microsoft.VisualStudio.Services.WebApi;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines a release model.
    /// </summary>
    public class Release
    {
        /// <summary>
        /// Gets or sets the id of the release.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the date when the release was created.
        /// </summary>
        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the date when the release was modified.
        /// </summary>
        [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the identity reference of the user, who modified the release.
        /// </summary>
        [JsonProperty(PropertyName = "modifiedBy")]
        public IdentityRef ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the identity reference of the user, who created the release.
        /// </summary>
        [JsonProperty(PropertyName = "createdBy")]
        public IdentityRef CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the description of the release.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the reason of the release.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the release name format.
        /// </summary>
        [JsonProperty(PropertyName = "releaseNameFormat")]
        public string ReleaseNameFormat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to keep the release forever.
        /// </summary>
        [JsonProperty(PropertyName = "keepForever")]
        public bool KeepForever { get; set; }

        /// <summary>
        /// Gets or sets the release definition.
        /// </summary>
        [JsonProperty(PropertyName = "releaseDefinition")]
        public ReleaseDefinition ReleaseDefinition { get; set; }

        /// <summary>
        /// Gets or sets the log container url.
        /// </summary>
        [JsonProperty(PropertyName = "logsContainerUrl")]
        public string LogsContainerUrl { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the reference links.
        /// </summary>
        [JsonProperty(PropertyName = "_links")]
        public ReferenceLinks Links { get; set; }

        /// <summary>
        /// Gets or sets the release environment.
        /// </summary>
        [JsonProperty(PropertyName = "environments")]
        public ReleaseEnvironment[] Environments { get; set; }

        /// <summary>
        /// Gets or sets the defintion snapshot revision.
        /// </summary>
        [JsonProperty(PropertyName = "definitionSnapshotRevision")]
        public int DefinitionSnapshotRevision { get; set; }

        /// <summary>
        /// Gets or sets the project reference of the release.
        /// </summary>
        [JsonProperty(PropertyName = "projectReference")]
        public ProjReference ProjectReference { get; set; }

        /// <summary>
        /// Gets or sets the artifacts of the release.
        /// </summary>
        [JsonProperty(PropertyName = "artifacts")]
        public Artifact[] Artifacts { get; set; }
    }
}