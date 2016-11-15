namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines the release deployment phase.
    /// </summary>
    public class ReleaseDeploymentPhase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Gets or sets the phase type.
        /// </summary>
        [JsonProperty(PropertyName = "phaseType")]
        public string PhaseType { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the run plan id.
        /// </summary>
        [JsonProperty(PropertyName = "runPlanId")]
        public Guid RunPlanId { get; set; }

        /// <summary>
        /// Gets or sets all deployment jobs of the release deployment phase.
        /// </summary>
        [JsonProperty(PropertyName = "deploymentJobs")]
        public DeploymentJob[] DeploymentJobs { get; set; }

        /// <summary>
        /// Gets or sets the manual interventions.
        /// </summary>
        [JsonProperty(PropertyName = "manualInterventions")]
        public dynamic ManualInterventions { get; set; }
    }
}