namespace VSTSInfoscreen.VSTS
{
    using Microsoft.TeamFoundation.Build.WebApi;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines a release job.
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Gets or sets the id of the release job.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the timeline record id.
        /// </summary>
        [JsonProperty(PropertyName = "timelineRecordId")]
        public Guid TimelineRecordId { get; set; }

        /// <summary>
        /// Gets or sets the name of the job.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date, when the job was started.
        /// </summary>
        [JsonProperty(PropertyName = "dateStarted")]
        public DateTime DateStarted { get; set; }

        /// <summary>
        /// Gets or sets the date, when the job was ended.
        /// </summary>
        [JsonProperty(PropertyName = "dateEnded")]
        public DateTime DateEnded { get; set; }

        /// <summary>
        /// Gets or sets the start time of execution.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the finish time of execution.
        /// </summary>
        [JsonProperty(PropertyName = "finishTime")]
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// Gets or sets the status of the job.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the rank of the job.
        /// </summary>
        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Gets or sets all issues associated with this job.
        /// </summary>
        [JsonProperty(PropertyName = "issues")]
        public Issue[] Issues { get; set; }
        
        /// <summary>
        /// Gets or sets the agent responsible for this job.
        /// </summary>
        [JsonProperty(PropertyName = "agentName")]
        public string AgentName { get; set; }
    }
}