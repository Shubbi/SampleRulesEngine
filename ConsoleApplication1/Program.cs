using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoWorkflow;
using System.Activities;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var wfApplication = new WorkflowApplication(new ArpsWF());

            var idleEvent = new AutoResetEvent(false);
            wfApplication.Idle += eventArgs => idleEvent.Set();

            var syncEvent = new AutoResetEvent(false);

            wfApplication.Run();
            syncEvent.WaitOne();

            Console.ReadLine();
        }
    }
}
