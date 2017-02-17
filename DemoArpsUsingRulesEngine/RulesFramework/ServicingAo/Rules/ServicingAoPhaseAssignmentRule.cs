using DemoArps.RulesFramework;
using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.ServicingAo.Conditions;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.ServicingAo.Rules
{
    public class ServicingAoPhaseAssignmentRule : BaseRule<ArpsAward>
    {
        public override void Initialize(ArpsAward arpsAward)
        {
            Conditions.Add(new PhaseServicingAo(arpsAward.Phase));
        }

        public override ArpsAward Apply(ArpsAward arpsAward)
        {            
            arpsAward.ViewName = "Index";

            return arpsAward;
        }
    }
}