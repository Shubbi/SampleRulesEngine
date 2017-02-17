using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleRulesEngine;
using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.Initiator.RuleSets;
using DemoArps_Utils;
using DemoArps_Common;
using DemoArpsUsingRulesEngine.RulesFramework.Initiator.Rules;

namespace DemoArpsUsingRulesEngine.Controllers
{
    public class InitiatorController : Controller
    {
        // GET: Initiator
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            arpsAward = arpsAward ?? new ArpsAward();            

            arpsAward = arpsAward.ApplyRule<ArpsAward>(new InitiatorPhaseAssignmentRule());

            if (arpsAward.Phase != AwardPhase.Initiator)
            {
                return new HttpUnauthorizedResult();
            }

            SessionHelper.ArpsAward = arpsAward;

            return View(arpsAward.ViewName, arpsAward);
        }

        public ActionResult Post(ArpsAward arpsAward)
        {
            var arpsAwardFromSession = SessionHelper.ArpsAward;

            if (arpsAwardFromSession.Phase != AwardPhase.Initiator)
            {
                return new HttpUnauthorizedResult();
            }

            arpsAward = arpsAward.RunRuleSet<ArpsAward>(new InitiatorRuleSet());            

            SessionHelper.ArpsAward = arpsAward;

            return RedirectToAction(arpsAward.ViewName, arpsAward);
        }

        public ActionResult Done(ArpsAward arpsAward)
        {
            return View(@"~\Views\Shared\Done.cshtml", arpsAward);
        }       
    }
}