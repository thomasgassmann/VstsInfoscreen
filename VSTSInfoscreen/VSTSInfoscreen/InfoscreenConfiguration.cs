namespace VSTSInfoscreen
{
    using Microsoft.VisualStudio.Services.Common;
    using System;
    using System.Configuration;
    using System.Net;

    /// <summary>
    /// Contains the configuration for the Infoscreen.
    /// </summary>
    public class InfoscreenConfiguration
    {
        /// <summary>
        /// Contains the value for the singleton for the configuration.
        /// </summary>
        private static InfoscreenConfiguration config;

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoscreenConfiguration"/> class. 
        /// </summary>
        private InfoscreenConfiguration()
        {
        }

        /// <summary>
        /// Gets or sets the team project.
        /// </summary>
        public string TeamProject { get; set; }

        /// <summary>
        /// Gets or sets the timeframe in which builds should be requested.
        /// </summary>
        public TimeSpan GetBuildsTimeFrameForSucceededBuilds { get; set; }

        /// <summary>
        /// Gets or sets the timeframe in which releases should be requested.
        /// </summary>
        public TimeSpan GetReleasesTimeFrameForSucceededReleases { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the base uri.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets the api base uri.
        /// </summary>
        public string ApiBaseUri { get; set; }

        /// <summary>
        /// Gets or sets the Uri of the VSTS tenant.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when to update the iterations. 24 for example will update the iterations every 24 hours.
        /// </summary>
        public int UpdateIterationsHour { get; set; }

        /// <summary>
        /// Gets or sets the interval in which to update the additional information.
        /// </summary>
        public int UpdateAdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets the interavl in which to update the builds.
        /// </summary>
        public int UpdateBuilds { get; set; }

        /// <summary>
        /// Gets the interval in which to update the pull requests.
        /// </summary>
        public int UpdatePullRequests { get; set; }

        /// <summary>
        /// Gets the interval in which to update the releases.
        /// </summary>
        public int UpdateReleases { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the compact mode of the cards is active.
        /// </summary>
        public bool CompactMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to switch the cards.
        /// </summary>
        public bool SwitchCards { get; set; }

        /// <summary>
        /// Gets or sets the interval in which to switch the cards. Applies only, if the <see cref="SwitchCards"/> property is set to true.
        /// </summary>
        public int SwitchInterval { get; set; }

        /// <summary>
        /// Gets the additional information configuration.
        /// </summary>
        public AdditionalInformationConfiguration AdditionalInformation { get; } = new AdditionalInformationConfiguration();

        /// <summary>
        /// Gets the Vss basic credential used for authentication.
        /// </summary>
        public VssBasicCredential Credential =>
                new VssBasicCredential(string.Empty, this.AccessToken);

        /// <summary>
        /// Gets the network credential used for authentication via REST.
        /// </summary>
        public NetworkCredential NetworkCredential =>
            new NetworkCredential(string.Empty, this.AccessToken);

        /// <summary>
        /// Gets the instance of the <see cref="InfoscreenConfiguration"/> class. 
        /// </summary>
        public static InfoscreenConfiguration Instance
        {
            get
            {
                if (InfoscreenConfiguration.config == null)
                {
                    InfoscreenConfiguration.config = new InfoscreenConfiguration
                    {
                        GetBuildsTimeFrameForSucceededBuilds = TimeSpan.Parse(
                        ConfigurationManager.AppSettings[nameof(GetBuildsTimeFrameForSucceededBuilds)].ToString()),
                        AccessToken = ConfigurationManager.AppSettings[nameof(AccessToken)],
                        BaseUri = new Uri(ConfigurationManager.AppSettings[nameof(BaseUri)]),
                        TeamProject = ConfigurationManager.AppSettings[nameof(TeamProject)],
                        ApiBaseUri = ConfigurationManager.AppSettings[nameof(ApiBaseUri)],
                        UpdateIterationsHour = int.Parse(ConfigurationManager.AppSettings[nameof(UpdateIterationsHour)]),
                        UpdateAdditionalInformation = int.Parse(ConfigurationManager.AppSettings[nameof(UpdateAdditionalInformation)]),
                        UpdateBuilds = int.Parse(ConfigurationManager.AppSettings[nameof(UpdateBuilds)]),
                        UpdatePullRequests = int.Parse(ConfigurationManager.AppSettings[nameof(UpdatePullRequests)]),
                        UpdateReleases = int.Parse(ConfigurationManager.AppSettings[nameof(UpdateReleases)]),
                        CompactMode = bool.Parse(ConfigurationManager.AppSettings[nameof(CompactMode)]),
                        GetReleasesTimeFrameForSucceededReleases = TimeSpan.Parse(
                        ConfigurationManager.AppSettings[nameof(GetReleasesTimeFrameForSucceededReleases)]),
                        SwitchCards = bool.Parse(ConfigurationManager.AppSettings[nameof(SwitchCards)]),
                        SwitchInterval = int.Parse(ConfigurationManager.AppSettings[nameof(SwitchInterval)]),
                        Uri = new Uri(ConfigurationManager.AppSettings[nameof(Uri)])
                    };
                }

                return InfoscreenConfiguration.config;
            }
        }

        /// <summary>
        /// Defines which additional information cards to display.
        /// </summary>
        public class AdditionalInformationConfiguration
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AdditionalInformationConfiguration"/> class. 
            /// </summary>
            internal AdditionalInformationConfiguration()
            {
            }

            /// <summary>
            /// Gets or sets a value indicating whether to show the current iteration additional information.
            /// </summary>
            public bool CurrentIteration { get; set; } = bool.Parse(ConfigurationManager.AppSettings["CurrentIteration"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show the count of all failed builds in the last 7 days.
            /// </summary>
            public bool FailedBuildsLast7Days { get; set; } = bool.Parse(ConfigurationManager.AppSettings["FailedBuildsLast7Days"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show successful builds in the last 7 days.
            /// </summary>
            public bool SuccessfulBuildsLast7Days { get; set; } = bool.Parse(ConfigurationManager.AppSettings["SuccessfulBuildsLast7Days"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show the count of the open pull requests.
            /// </summary>
            public bool OpenPullRequests { get; set; } = bool.Parse(ConfigurationManager.AppSettings["OpenPullRequests"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show the count of pull request with merge conflicts.
            /// </summary>
            public bool PullRequestsWithMergeConflicts { get; set; } = bool.Parse(ConfigurationManager.AppSettings["PullRequestsWithMergeConflicts"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show the count of all work items set to state 'New'.
            /// </summary>
            public bool NewWorkItemCount { get; set; } = bool.Parse(ConfigurationManager.AppSettings["NewWorkItemCount"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show all team days off.
            /// </summary>
            public bool TeamDaysOff { get; set; } = bool.Parse(ConfigurationManager.AppSettings["TeamDaysOff"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show the capacity of each team member in a separate card.
            /// </summary>
            public bool DaysOffAndCapacityPerPerson { get; set; } = bool.Parse(ConfigurationManager.AppSettings["DaysOffAndCapacityPerPerson"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show the failed releases in the last 7 days.
            /// </summary>
            public bool FailedReleasesLast7Days { get; set; } = bool.Parse(ConfigurationManager.AppSettings["FailedReleasesLast7Days"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show the successful releases in the last 7 days.
            /// </summary>
            public bool SuccessfulReleasesLast7Days { get; set; } = bool.Parse(ConfigurationManager.AppSettings["SuccessfulReleasesLast7Days"]);

            /// <summary>
            /// Gets or sets a value indicating whether to show the completed pull requests in the last 7 days.
            /// </summary>
            public bool CompletedPullRequestsLast7Days { get; set; } = bool.Parse(ConfigurationManager.AppSettings["CompletedPullRequestsLast7Days"]); 
        }
    }
}