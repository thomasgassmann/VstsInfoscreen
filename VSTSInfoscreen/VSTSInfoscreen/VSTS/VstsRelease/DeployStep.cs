namespace VSTSInfoscreen.VSTS
{
    using Microsoft.VisualStudio.Services.WebApi;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines a deploy step.
    /// </summary>
    public class DeployStep
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the deployment id.
        /// </summary>
        [JsonProperty(PropertyName = "deploymentId")]
        public int DeploymentId { get; set; }

        /// <summary>
        /// Gets or sets the number of the current attempt to comlete the action.
        /// </summary>
        [JsonProperty(PropertyName = "attempt")]
        public int Attempt { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the status of the depoy step.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the operation status.
        /// </summary>
        [JsonProperty(PropertyName = "operationStatus")]
        public string OperationStatus { get; set; }

        /// <summary>
        /// Gets or sets all release deployment phases of the current deploy step.
        /// </summary>
        [JsonProperty(PropertyName = "releaseDeployPhases")]
        public ReleaseDeploymentPhase[] ReleaseDeploymentPhases { get; set; }

        /// <summary>
        /// Gets or sets the identity reference of the user, that started the current deploy step in the release.
        /// </summary>
        [JsonProperty(PropertyName = "requestedBy")]
        public IdentityRef RequestedBy { get; set; }

        /// <summary>
        /// Gets or sets a date indicating when the current deploy step was queued on.
        /// </summary>
        [JsonProperty(PropertyName = "queuedOn")]
        public DateTime QueuedOn { get; set; }

        /// <summary>
        /// Gets or sets a identity reference to the user that last modified the current deploy step.
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedBy")]
        public IdentityRef LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or set the date the current deploy step was last modified.
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedOn")]
        public DateTime LastModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when the current deploy step was started.
        /// </summary>
        [JsonProperty(PropertyName = "hasStarted")]
        public bool HasStarted { get; set; }

        /// <summary>
        /// Gets or sets all release tasks in the current deploy step.
        /// </summary>
        [JsonProperty(PropertyName = "tasks")]
        public ReleaseTask[] Tasks { get; set; }

        /// <summary>
        /// Gets or sets the job of the current deploy step.
        /// </summary>
        [JsonProperty(PropertyName = "job")]
        public Job Job { get; set; }

        /// <summary>
        /// Gets or sets the id of the run plan.
        /// </summary>
        [JsonProperty(PropertyName = "runPlanId")]
        public Guid RunPlanId { get; set; }
    }
}