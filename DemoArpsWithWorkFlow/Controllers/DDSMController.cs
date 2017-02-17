﻿using System;
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
    public class DDSMController : Controller
    {
        // GET: DDSM
        public ActionResult Index()
        {
            var arpsAward = SessionHelper.ArpsAward;

            if (arpsAward == null || arpsAward.Phase != DemoArps_Common.AwardPhase.Ddsm)
            {
                throw new Exception();
            }

            var viewName = WorkflowHelper.GetViewName(arpsAward);

            return View(viewName, arpsAward);
        }
        [HttpPost]
        public ActionResult Post(ArpsAward arpsAward, string button)
        {
            var arpsAwardFromSession = SessionHelper.ArpsAward;

            if (arpsAwardFromSession == null || arpsAwardFromSession.Phase != DemoArps_Common.AwardPhase.Ddsm)
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
