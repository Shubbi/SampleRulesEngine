using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DemoArps_Utils;
using DemoWorkflow;
using DemoArps_Models;

namespace DemoArpsWithWorkFlow.ControllerHelperClasses
{
    public class WorkflowHelper
    {
        public static string GetViewName(ArpsAward arpsAward)
        {
            var viewName = string.Empty;
            var dictionary = new Dictionary<string, Object>();
            dictionary.Add("ArpsAward", arpsAward);

            var wfApplication = new WorkflowApplication(new ArpsWF(), dictionary);

            var idleEvent = new AutoResetEvent(false);
            wfApplication.Idle += eventArgs => idleEvent.Set();

            var syncEvent = new AutoResetEvent(false);

            wfApplication.Completed += delegate(WorkflowApplicationCompletedEventArgs args)
            {
                if (args.CompletionState == ActivityInstanceState.Closed)
                {
                    try
                    {
                        // Accessing the output arguments dictionary                    
                        // might throw a KeyNotFoundException or                    
                        // InvalidCastException                                                
                        viewName = arpsAward.ViewName;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        // Must be sure to unblock the main thread                    
                        syncEvent.Set();
                    }
                }
            };
            try
            {
                wfApplication.Run();
            }
            catch (Exception)
            {
                
                throw;
            }
            
            syncEvent.WaitOne();
            SessionHelper.ArpsAward = arpsAward;
            return viewName;
        }
    }
}