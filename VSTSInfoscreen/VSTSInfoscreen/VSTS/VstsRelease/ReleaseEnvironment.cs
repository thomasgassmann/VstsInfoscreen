namespace VSTSInfoscreen.VSTS
{
    using Microsoft.VisualStudio.Services.WebApi;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a release environment.
    /// </summary>
    public class ReleaseEnvironment
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the release id.
        /// </summary>
        [JsonProperty(PropertyName = "releaseId")]
        public int ReleaseId { get; set; }

        /// <summary>
        /// Gets or sets the name of the environment.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the current status of the environment.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the variables of the release environment.
        /// </summary>
        [JsonProperty(PropertyName = "variables")]
        public Dictionary<string, object> Variables { get; set; }

        /// <summary>
        /// Gets or sets the predeploy approvals.
        /// </summary>
        [JsonProperty(PropertyName = "preDeployApprovals")]
        public DeployApproval[] PreDeployApprovals { get; set; }

        /// <summary>
        /// Gets or sets the postdeploy approvals.
        /// </summary>
        [JsonProperty(PropertyName = "postDeployApprovals")]
        public DeployApproval[] PostDeployApprovals { get; set; }

        /// <summary>
        /// Gets or sets the pre approval snapshot.
        /// </summary>
        [JsonProperty(PropertyName = "preApprovalsSnapshot")]
        public ApprovalSnapshot PreApprovalsSnapshot { get; set; }

        /// <summary>
        /// Gets or sets the post approval snapshot.
        /// </summary>
        [JsonProperty(PropertyName = "postApprovalsSnapshot")]
        public ApprovalSnapshot PostApprovalSnapshot { get; set; }

        /// <summary>
        /// Gets or sets all deploy steps of the environment.
        /// </summary>
        [JsonProperty(PropertyName = "deploySteps")]
        public DeployStep[] DeploySteps { get; set; }

        /// <summary>
        /// Gets or sets the rank of the environment.
        /// </summary>
        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }

        /// <summary>
        /// Gets or sets the definition environment id.
        /// </summary>
        [JsonProperty(PropertyName = "definitionEnvironmentId")]
        public int DefinitionEnvironmentId { get; set; }

        /// <summary>
        /// Gets or sets the queue id.
        /// </summary>
        [JsonProperty(PropertyName = "queueId")]
        public int QueueId { get; set; }
        
        /// <summary>
        /// Gets or sets the environment options.
        /// </summary>
        [JsonProperty(PropertyName = "environmentOptions")]
        public EnvironmentOptions EnvironmentOptions { get; set; }

        /// <summary>
        /// Gets or sets the demands.
        /// </summary>
        [JsonProperty(PropertyName = "demands")]
        public string[] Demands { get; set; }

        /// <summary>
        /// Gets or sets the conditions.
        /// </summary>
        [JsonProperty(PropertyName = "conditions")]
        public Condition[] Conditions { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the environment.
        /// </summary>
        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the modified date of the release environment.
        /// </summary>
        [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the workflow tasks.
        /// </summary>
        [JsonProperty(PropertyName = "workflowTasks")]
        public WorkflowTask[] WorkflowTasks { get; set; }

        /// <summary>
        /// Gets or sets the deployment phase snapshot.
        /// </summary>
        [JsonProperty(PropertyName = "deployPhasesSnapshot")]
        public DeploymentPhaseSnapshot[] DeployPhasesSnapshot { get; set; }

        /// <summary>
        /// Gets or sets the owner of the release environment.
        /// </summary>
        [JsonProperty(PropertyName = "owner")]
        public IdentityRef Owner { get; set; }

        /// <summary>
        /// Gets or sets the schedules of the release environment.
        /// </summary>
        [JsonProperty(PropertyName = "schedules")]
        public string[] Schedules { get; set; }

        /// <summary>
        /// Gets or sets the release definition of the release environment.
        /// </summary>
        [JsonProperty(PropertyName = "releaseDefinition")]
        public ReleaseDefinition ReleaseDefinition { get; set; }

        /// <summary>
        /// Gets or sets the user, who created the release environment.
        /// </summary>
        [JsonProperty(PropertyName = "releaseCreatedBy")]
        public IdentityRef ReleaseCreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the trigger reason.
        /// </summary>
        [JsonProperty(PropertyName = "triggerReason")]
        public string TriggerReason { get; set; }

        /// <summary>
        /// Gets or sets the time needed to deploy.
        /// </summary>
        [JsonProperty(PropertyName = "timeToDeploy")]
        public double TimeToDeploy { get; set; }

        /// <summary>
        /// Gets or sets the reference to the release.
        /// </summary>
        [JsonProperty(PropertyName = "release")]
        public ReleaseReference Release { get; set; }
    }
}