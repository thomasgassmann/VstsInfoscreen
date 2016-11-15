namespace VSTSInfoscreen.Models
{
    /// <summary>
    /// Defines the view model for the release environment.
    /// </summary>
    public class ReleaseEnvironmentViewModel
    {
        /// <summary>
        /// Gets or sets the name of the release environment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the deployment status of the release environment.
        /// </summary>
        public string DeploymentStatus { get; set; }
    }
}