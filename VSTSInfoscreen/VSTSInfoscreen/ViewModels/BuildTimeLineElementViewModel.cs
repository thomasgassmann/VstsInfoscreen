namespace VSTSInfoscreen.Models
{
    /// <summary>
    /// Defines the view model for the build time line element.
    /// </summary>
    public class BuildTimeLineElementViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the worker name for this step.
        /// </summary>
        public string WorkerName { get; set; }

        /// <summary>
        /// Gets or sets a value indiating whether the step was successful or not.
        /// </summary>
        public bool Successful { get; set; }
    }
}
