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
    public class NominatorDifferentThanInitiatorRule : BaseRule<ArpsAward>
    {
        public override void Initialize(ArpsAward arpsAward)
        {
            Conditions.Add(new NominatorDifferentThanInitiator(arpsAward.NominatorSso, arpsAward.InitiatorSso));
        }

        public override ArpsAward Apply(ArpsAward arpsAward)
        {
            arpsAward.Phase = AwardPhase.Nominator;
            arpsAward.ViewName = "Done";
            return arpsAward;
        }
    }
}