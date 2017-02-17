using DemoArps_Models;
using DemoArps_Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleRulesEngine;
using DemoArpsUsingRulesEngine.RulesFramework.Nominator.Rules;
using DemoArps_Common;

namespace DemoArpsUsingRulesEngine.Controllers
{
    public class NominatorController : Controller
    {
        // GET: Nominator
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            arpsAward.ApplyRule<ArpsAward>(new NominatorPhaseAssignmentRule());

            if (arpsAward.Phase != AwardPhase.Nominator)
            {
                return new HttpUnauthorizedResult();
            }

            return View(arpsAward.ViewName, arpsAward);
        }

        [HttpPost]
        public ActionResult Post(ArpsAward arpsAward, string button)
        {
            arpsAward.Phase = SessionHelper.ArpsAward.Phase;

            if (arpsAward.Phase != AwardPhase.Nominator)
            {
                return new HttpUnauthorizedResult();
            }

            arpsAward.UserSelection = button;
            arpsAward.ApplyRule<ArpsAward>(new NominatorSelectionRule());            

            SessionHelper.ArpsAward = arpsAward;

            return RedirectToAction(arpsAward.ViewName, arpsAward);
        }

        public ActionResult Done(ArpsAward arpsAward)
        {
            return View(@"~\Views\Shared\Done.cshtml", arpsAward);
        }   
    }
}