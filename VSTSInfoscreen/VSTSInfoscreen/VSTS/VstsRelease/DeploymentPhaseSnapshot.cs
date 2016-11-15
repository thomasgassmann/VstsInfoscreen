namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the snapshot in the deployment phase.
    /// </summary>
    public class DeploymentPhaseSnapshot
    {
        /// <summary>
        /// Gets or sets the deployment input.
        /// </summary>
        [JsonProperty(PropertyName = "deploymentInput")]
        public DeploymentInput DeploymentInput { get; set; }

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
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets all workflow tasks assocated with this snapshot.
        /// </summary>
        [JsonProperty(PropertyName = "workflowTasks")]
        public WorkflowTask[] WorkflowTaks { get; set; }
    }
}