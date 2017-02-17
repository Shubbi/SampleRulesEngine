using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoArps_Utils;

namespace Plain.Controllers
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