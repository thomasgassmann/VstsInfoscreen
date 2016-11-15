namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines a workflow task.
    /// </summary>
    public class WorkflowTask
    {
        /// <summary>
        /// Gets or sets the id of the task.
        /// </summary>
        [JsonProperty(PropertyName = "taskId")]
        public Guid TaskId { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the workflow task is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the workflow task should always run.
        /// </summary>
        [JsonProperty(PropertyName = "alwaysRun")]
        public bool AlwaysRun { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the workflow task should continue on error.
        /// </summary>
        [JsonProperty(PropertyName = "continueOnError")]
        public bool ContinueOnError { get; set; }

        /// <summary>
        /// Gets or sets the timeout in minutes.
        /// </summary>
        [JsonProperty(PropertyName = "timeoutInMinutes")]
        public int TimeoutInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the definition type.
        /// </summary>
        [JsonProperty(PropertyName = "definitionType")]
        public string DefinitionType { get; set; }

        /// <summary>
        /// Gets or sets the inputs of the workflow task.
        /// </summary>
        [JsonProperty(PropertyName = "inputs")]
        public Inputs Inputs { get; set; }
    }
}