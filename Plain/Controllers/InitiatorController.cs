using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoArps_Common;
using DemoArps_Models;
using DemoArps_Utils;

namespace Plain.Controllers
{
    public class InitiatorController : Controller
    {
        // GET: Initiator
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            arpsAward = arpsAward ?? new ArpsAward();

            if (!IsInitiatorPhase(arpsAward))
            {
                return new HttpUnauthorizedResult();
            }
            
            arpsAward.Phase = AwardPhase.Initiator;
            SessionHelper.ArpsAward  = arpsAward;

            return View("Index", arpsAward);
        }

        public ActionResult Post(ArpsAward arpsAward)
        {
            var arpsAwardFromSession = SessionHelper.ArpsAward;

            if(arpsAwardFromSession.Phase != AwardPhase.Initiator)
            {
                return new HttpUnauthorizedResult();
            }

            arpsAward.Phase = (arpsAward.InitiatorSso == arpsAward.NominatorSso)
                ? AwardPhase.ServicingAo : AwardPhase.Nominator;

            SessionHelper.ArpsAward = arpsAward;

            return RedirectToAction("Done", arpsAward);
        }

        public ActionResult Done(ArpsAward arpsAward)
        {
            return View(@"~\Views\Shared\Done.cshtml", arpsAward);
        }

        private static bool IsInitiatorPhase(ArpsAward arpsAward)
        {
            return string.IsNullOrWhiteSpace(arpsAward.Phase)
                || arpsAward.Phase == AwardPhase.Initiator;
        }
    }
}