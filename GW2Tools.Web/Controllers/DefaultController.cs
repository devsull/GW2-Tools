using System.Web.Mvc;
using GW2Tools.Core;

namespace GW2Tools.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}