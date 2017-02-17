using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using DemoArpsWithWorkFlow.ControllerHelperClasses;
using DemoArps_Utils;
using DemoWorkflow;
using DemoArps_Models;

namespace DemoArpsWithWorkFlow.Controllers
{
    public class DivisionDirectorController : Controller
    {
        // GET: Director
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            if (arpsAward == null || arpsAward.Phase != DemoArps_Common.AwardPhase.DivisionDirector)
            {
                throw new Exception();
            }

            var viewName = WorkflowHelper.GetViewName(arpsAward);

            return View(viewName, arpsAward);
        }

        // POST: Director/
        [HttpPost]
        public ActionResult Post(ArpsAward arpsAward, string button)
        {
            var arpsAwardFromSession = SessionHelper.ArpsAward;

            if (arpsAwardFromSession == null || arpsAwardFromSession.Phase != DemoArps_Common.AwardPhase.DivisionDirector)
            {
                throw new Exception();
            }

            arpsAward.Phase = arpsAwardFromSession.Phase;
            arpsAward.UserSelection = button;

            var viewName = WorkflowHelper.GetViewName(arpsAward);

            return View(viewName, arpsAward);
        }
    }
}
