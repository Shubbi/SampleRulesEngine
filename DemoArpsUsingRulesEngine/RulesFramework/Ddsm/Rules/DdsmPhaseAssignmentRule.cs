using DemoArps.RulesFramework;
using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.Ddsm.Conditions;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Ddsm.Rules
{
    public class DdsmPhaseAssignmentRule : BaseRule<ArpsAward>
    {
        public override void Initialize(ArpsAward arpsAward)
        {
            Conditions.Add(new PhaseDdsm(arpsAward.Phase));
        }

        public override ArpsAward Apply(ArpsAward arpsAward)
        {            
            arpsAward.ViewName = "Index";

            return arpsAward;
        }
    }
}