namespace VSTSInfoscreen.Models
{
    using Microsoft.TeamFoundation.Build.WebApi;

    /// <summary>
    /// Contains all extensions for the <see cref="BuildViewModel"/>. 
    /// </summary>
    public static class BuildViewModelExtensions
    {
        /// <summary>
        /// Gets the text to display the icon depending on the build status and build result.
        /// </summary>
        /// <param name="model">The <see cref="BuildViewModel"/> to extend.</param>
        /// <returns>Returns the icon string.</returns>
        public static string GetIcon(this BuildViewModel model)
        {
            if (model.BuildStatus == BuildStatus.Completed)
            {
                if (model.BuildResult == BuildResult.Succeeded ||
                    model.BuildResult == BuildResult.PartiallySucceeded)
                {
                    return "done";
                }
                else if (model.BuildResult == BuildResult.Failed)
                {
                    return "cancel";
                }
                else if (model.BuildResult == BuildResult.Canceled)
                {
                    return "backspace";
                }
                else
                {
                    return "help";
                }
            }
            else if (model.BuildStatus == BuildStatus.InProgress)
            {
                return "refresh";
            }
            else if (model.BuildStatus == BuildStatus.Postponed)
            {
                return "schedule";
            }
            else if (model.BuildStatus == BuildStatus.Cancelling)
            {
                return "backspace";
            }
            else
            {
                return "help";
            }
        }
    }
}