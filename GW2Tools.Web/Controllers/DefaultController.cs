// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultController.cs" company="Devin Sullivan">
//   copy write
// </copyright>
// <summary>
//   Defines the DefaultController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2Tools.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The default controller.
    /// </summary>
    public class DefaultController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}