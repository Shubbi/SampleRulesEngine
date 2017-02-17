using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleRulesEngine;
using DemoArps_Common;
using DemoArps_Models;
using DemoArps_Utils;
using DemoArpsUsingRulesEngine.RulesFramework.DivisionDirector.Rules;
using DemoArpsUsingRulesEngine.RulesFramework.DivisionDirectorRuleSet.RuleSets;

namespace DemoArpsUsingRulesEngine.Controllers
{
    public class DivisionDirectorController : Controller
    {
        // GET: DivisionDirector
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            arpsAward.ApplyRule<ArpsAward>(new DivisionDirectorPhaseAssignmentRule());

            if (arpsAward.Phase != AwardPhase.DivisionDirector)
            {
                return new HttpUnauthorizedResult();
            }

            return View(arpsAward.ViewName, arpsAward);            
        }

        [HttpPost]
        public ActionResult Post(ArpsAward arpsAward, string button)
        {
            arpsAward.Phase = SessionHelper.ArpsAward.Phase;

            if (arpsAward.Phase != AwardPhase.DivisionDirector)
            {
                return new HttpUnauthorizedResult();
            }

            arpsAward.UserSelection = button;
            arpsAward = arpsAward.RunRuleSet<ArpsAward>(new DivisionDirectorRuleSet());

            SessionHelper.ArpsAward = arpsAward;

            return RedirectToAction(arpsAward.ViewName, arpsAward);            
        }        

        public ActionResult Done(ArpsAward arpsAward)
        {
            return View(@"~\Views\Shared\Done.cshtml", arpsAward);
        }
    }
}