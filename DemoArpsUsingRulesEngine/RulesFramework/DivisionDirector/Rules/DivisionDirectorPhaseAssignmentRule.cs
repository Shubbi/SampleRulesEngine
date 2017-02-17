using DemoArps.RulesFramework;
using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.DivisionDirector.Conditions;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.DivisionDirector.Rules
{
    public class DivisionDirectorPhaseAssignmentRule : BaseRule<ArpsAward>
    {
        public override void Initialize(ArpsAward arpsAward)
        {
            Conditions.Add(new PhaseDivisionDirector(arpsAward.Phase));
        }

        public override ArpsAward Apply(ArpsAward arpsAward)
        {            
            arpsAward.ViewName = "Index";

            return arpsAward;
        }
    }
}