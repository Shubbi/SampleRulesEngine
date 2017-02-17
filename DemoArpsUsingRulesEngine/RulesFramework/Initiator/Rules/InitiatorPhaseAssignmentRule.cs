using DemoArps.RulesFramework;
using DemoArps.RulesFramework;
using DemoArps_Common;
using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.Initiator.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Initiator.Rules
{
    public class InitiatorPhaseAssignmentRule : BaseRule<ArpsAward>
    {
        public override void Initialize(ArpsAward arpsAward)
        {
            Conditions.Add(new PhaseEmptyOrInitiator(arpsAward.Phase));
        }

        public override ArpsAward Apply(ArpsAward arpsAward)
        {
            arpsAward.Phase = AwardPhase.Initiator;
            arpsAward.ViewName = "Index";

            return arpsAward;
        }
    }
}