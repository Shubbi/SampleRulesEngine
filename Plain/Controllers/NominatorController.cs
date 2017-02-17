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
    public class NominatorController : Controller
    {
        // GET: Nominator
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            if (!IsNominatorPhase(arpsAward))
            {
                return new HttpUnauthorizedResult();
            }

            return View(arpsAward);
        }

        [HttpPost]
        public ActionResult Post(ArpsAward arpsAward, string button)
        {
            var arpsAwardFromSession = SessionHelper.ArpsAward;

            if (!IsNominatorPhase(arpsAwardFromSession))
            {
                return new HttpUnauthorizedResult();
            }

            arpsAward.Phase = button == "Approve" ? AwardPhase.ServicingAo : 
                button == "Return" ? AwardPhase.Initiator :
                AwardPhase.End;

            SessionHelper.ArpsAward = arpsAward;

            return RedirectToAction("Done", arpsAward);
        }

        public ActionResult Done(ArpsAward arpsAward)
        {
            return View(@"~\Views\Shared\Done.cshtml", arpsAward);
        }

        private static bool IsNominatorPhase(ArpsAward arpsAward)
        {
            return arpsAward != null && arpsAward.Phase == AwardPhase.Nominator;
        }
    }
}