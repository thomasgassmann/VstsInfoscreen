namespace VSTSInfoscreen.Models
{
    /// <summary>
    /// Contains all extensions for the release environment model.
    /// </summary>
    public static class ReleaseEnvironmentModelExtensions
    {
        /// <summary>
        /// Gets the color depending on the release deployment status.
        /// </summary>
        /// <param name="model">The model to extend.</param>
        /// <returns>Returns the color.</returns>
        public static string GetColor(this ReleaseEnvironmentViewModel model)
        {
            switch (model.DeploymentStatus)
            {
                case "inProgress":
                    return "#007ACC";
                case "rejected":
                    return "#DA0A00";
                case "succeeded":
                    return "#339933";
                default:
                    return "#999999";
            }
        }
    }
}