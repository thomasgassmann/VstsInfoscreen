namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the parallel execution of the releases.
    /// </summary>
    public class ParallelExecution
    {
        /// <summary>
        /// Gets or sets the multipliers.
        /// </summary>
        [JsonProperty(PropertyName = "multipliers")]
        public string Multipliers { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of agents for parallel execution in a release.
        /// </summary>
        [JsonProperty(PropertyName = "maxNumberOfAgents")]
        public int MaxNumberOfAgents { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to continue on error.
        /// </summary>
        [JsonProperty(PropertyName = "continueOnError")]
        public bool ContinueOnError { get; set; }

        /// <summary>
        /// Gets or sets the type of the parallel execution.
        /// </summary>
        [JsonProperty(PropertyName = "parallelExecutionType")]
        public string ParallelExecutionType { get; set; }
    }
}