namespace VSTSInfoscreen.VSTS
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the approval snapshots.
    /// </summary>
    public class ApprovalSnapshot
    {
        /// <summary>
        /// Gets or sets the approvals.
        /// </summary>
        [JsonProperty(PropertyName = "approvals")]
        public Approval[] Approvals { get; set; }
    }
}