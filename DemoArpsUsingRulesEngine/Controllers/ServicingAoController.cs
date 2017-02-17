using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleRulesEngine;
using DemoArps_Common;
using DemoArps_Models;
using DemoArps_Utils;
using DemoArpsUsingRulesEngine.RulesFramework.ServicingAo.Rules;
using DemoArpsUsingRulesEngine.RulesFramework.Nominator.Rules;

namespace DemoArpsUsingRulesEngine.Controllers
{
    public class ServicingAoController : Controller
    {
        // GET: ServicingAO
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            arpsAward.ApplyRule<ArpsAward>(new ServicingAoPhaseAssignmentRule());

            if (arpsAward.Phase != AwardPhase.ServicingAo)
            {
                return new HttpUnauthorizedResult();
            }

            return View(arpsAward.ViewName, arpsAward);            
        }

        [HttpPost]
        public ActionResult Post(ArpsAward arpsAward, string button)
        {
            arpsAward.Phase = SessionHelper.ArpsAward.Phase;

            if (arpsAward.Phase != AwardPhase.ServicingAo)
            {
                return new HttpUnauthorizedResult();
            }

            arpsAward.UserSelection = button;
            arpsAward.ApplyRule<ArpsAward>(new ServicingAoSelectionRule());

            SessionHelper.ArpsAward = arpsAward;

            return RedirectToAction(arpsAward.ViewName, arpsAward);
        }

        public ActionResult Done(ArpsAward arpsAward)
        {
            return View(@"~\Views\Shared\Done.cshtml", arpsAward);
        }
    }
}