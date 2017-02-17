using DemoArps.RulesFramework;
using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.Nominator.Conditions;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Nominator.Rules
{
    public class NominatorPhaseAssignmentRule : BaseRule<ArpsAward>
    {
        public override void Initialize(ArpsAward arpsAward)
        {
            Conditions.Add(new PhaseNominator(arpsAward.Phase));
        }

        public override ArpsAward Apply(ArpsAward arpsAward)
        {            
            arpsAward.ViewName = "Index";

            return arpsAward;
        }
    }
}