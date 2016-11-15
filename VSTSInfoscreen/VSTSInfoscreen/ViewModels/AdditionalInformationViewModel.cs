namespace VSTSInfoscreen.Models
{
    /// <summary>
    /// Defines the view for the additional information to display on top of the Infoscreen.
    /// </summary>
    public class AdditionalInformationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalInformationViewModel"/> class. 
        /// </summary>
        /// <param name="title">The title of the additional information.</param>
        /// <param name="info">The information to display.</param>
        public AdditionalInformationViewModel(string title, string info)
        {
            this.Title = title;
            this.Information = info;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        public string Information { get; set; }
    }
}