using DemoArps_Utils;
using System.Web.Mvc;

namespace DemoArpsUsingRulesEngine.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionHelper.ArpsAward = null;
            return RedirectToAction("Index", "Initiator");
        }
    }
}