namespace VSTSInfoscreen.Controllers
{
    using System.Web.Mvc;
    using VSTS;

    /// <summary>
    /// The data controller for getting the data in the javascript.
    /// </summary>
    public class DataController : Controller
    {
        /// <summary>
        /// Gets the additional information.
        /// </summary>
        /// <returns>Returns the rendered additional information.</returns>
        [HttpPost]
        public ActionResult GetAdditionalInformation()
        {
            var model = VstsContext.Instance.AdditionalInformationService.GetAdditionalInformationViewModels();
            return this.PartialView("_AdditionalInformationList", model);
        }

        /// <summary>
        /// Gets the builds.
        /// </summary>
        /// <returns>Returns the rendered builds.</returns>
        [HttpPost]
        public ActionResult GetBuilds()
        {
            var model = VstsContext.Instance.BuildService.GetBuildViewModels();
            return this.PartialView("_BuildRowList", model);
        }

        /// <summary>
        /// Gets the pull requests.
        /// </summary>
        /// <returns>Returns the rendered pull requests.</returns>
        [HttpPost]
        public ActionResult GetPullRequests()
        {
            var model = VstsContext.Instance.PullRequestService.GetPullRequestViewModels();
            return this.PartialView("_PullRequestRowList", model);
        }

        /// <summary>
        /// Gets the releases.
        /// </summary>
        /// <returns>Returns the rendered releases.</returns>
        [HttpPost]
        public ActionResult GetReleases()
        {
            var model = VstsContext.Instance.ReleaseService.GetReleaseViewModels();
            return this.PartialView("_ReleaseRowList", model);
        }
    }
}