namespace VSTSInfoscreen.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The main home controller for the default view.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The default view.
        /// </summary>
        /// <returns>Returns the default view.</returns>
        public ActionResult InfoScreen()
        {
            return this.View();
        }
    }
}