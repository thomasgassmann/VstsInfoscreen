namespace VSTSInfoscreen.VSTS
{
    using System;

    /// <summary>
    /// Contains all instances to get the necessary information.
    /// </summary>
    public class VstsContext
    {
        /// <summary>
        /// Contains the instance.
        /// </summary>
        private static readonly Lazy<VstsContext> instance = new Lazy<VstsContext>(() => new VstsContext(InfoscreenConfiguration.Instance));

        /// <summary>
        /// Contains the additional information service.
        /// </summary>
        private readonly Lazy<AdditionalInformationService> additionalInformationService;

        /// <summary>
        /// Contains the release service.
        /// </summary>
        private readonly Lazy<ReleaseService> releaseService;

        /// <summary>
        /// Contains the pull request service.
        /// </summary>
        private readonly Lazy<PullRequestService> pullRequestService;

        /// <summary>
        /// Contains the build service.
        /// </summary>
        private readonly Lazy<BuildService> buildService;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="VstsContext"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        private VstsContext(InfoscreenConfiguration configuration)
        {
            this.Configuration = configuration;
            this.additionalInformationService = new Lazy<AdditionalInformationService>(() => new AdditionalInformationService(this.Configuration));
            this.releaseService = new Lazy<ReleaseService>(() => new ReleaseService(this.Configuration));
            this.pullRequestService = new Lazy<PullRequestService>(() => new PullRequestService(this.Configuration));
            this.buildService = new Lazy<BuildService>(() => new BuildService(this.Configuration));
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static VstsContext Instance => VstsContext.instance.Value;

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        protected InfoscreenConfiguration Configuration { get; }

        /// <summary>
        /// Gets the additional information service.
        /// </summary>
        public AdditionalInformationService AdditionalInformationService => this.additionalInformationService.Value;

        /// <summary>
        /// Gets the release service.
        /// </summary>
        public ReleaseService ReleaseService => this.releaseService.Value;

        /// <summary>
        /// Gets the pull request service.
        /// </summary>
        public PullRequestService PullRequestService => this.pullRequestService.Value;
        
        /// <summary>
        /// Gets the build service.
        /// </summary>
        public BuildService BuildService => this.buildService.Value;
    }
}