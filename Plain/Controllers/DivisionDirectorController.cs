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
    public class DivisionDirectorController : Controller
    {
        // GET: DivisionDirector
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            if (!IsDivisionDirectorPhase(arpsAward))
            {
                return new HttpUnauthorizedResult();
            }

            return View(arpsAward);
        }

        [HttpPost]
        public ActionResult Post(ArpsAward arpsAward, string button)
        {
            var arpsAwardFromSession = SessionHelper.ArpsAward;

            if (!IsDivisionDirectorPhase(arpsAwardFromSession))
            {
                return new HttpUnauthorizedResult();
            }

            SetAwardPhase(arpsAward, button);

            SessionHelper.ArpsAward = arpsAward;

            return RedirectToAction("Done", arpsAward);
        }

        private void SetAwardPhase(ArpsAward arpsAward, string button)
        {
            arpsAward.Phase =
                button == "Approve"
                    ? GetAwardPhaseForApproval(arpsAward, button)
                    : button == "Return"
                        ? AwardPhase.Initiator
                        : AwardPhase.End;
        }

        private string GetAwardPhaseForApproval(ArpsAward arpsAward, string button)
        {
            return arpsAward.CashAmount > 5000.0m ?
                    AwardPhase.Ddsm : AwardPhase.Ohr;
        }

        public ActionResult Done(ArpsAward arpsAward)
        {
            return View(@"~\Views\Shared\Done.cshtml", arpsAward);
        }

        private static bool IsDivisionDirectorPhase(ArpsAward arpsAward)
        {
            return arpsAward != null && arpsAward.Phase == AwardPhase.DivisionDirector;
        }
    }
}