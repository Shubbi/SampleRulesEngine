using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//using DemoArpsWithWorkFlow.Controllers.ControllerHelperClasses;
using DemoArpsWithWorkFlow.ControllerHelperClasses;
using DemoArps_Utils;
using DemoWorkflow;
using DemoArps_Models;

namespace DemoArpsWithWorkFlow.Controllers
{
    public class InitiatorController : Controller
    {
        // GET: Initiator
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            //GetName getname = new GetName();

            arpsAward = arpsAward ?? new ArpsAward();
            arpsAward.ViewName = string.Empty;
            var viewName = WorkflowHelper.GetViewName(arpsAward);
            return View(viewName);
        }
      
        [HttpPost]
        public ActionResult Post(ArpsAward arpsAward)
        {
           // GetName getname = new GetName();
            var arpsAwardFromSession = SessionHelper.ArpsAward;
            arpsAward.Phase = arpsAwardFromSession.Phase;
            var viewName = WorkflowHelper.GetViewName(arpsAward);
            return View(viewName, arpsAward);
        }
    }
}