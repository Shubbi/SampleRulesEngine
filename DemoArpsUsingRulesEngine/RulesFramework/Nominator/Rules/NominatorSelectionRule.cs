using DemoArps.RulesFramework;
using DemoArps_Common;
using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.Nominator.Conditions;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Nominator.Rules
{
    public class NominatorSelectionRule : BaseRule<ArpsAward>
    {
        public override void Initialize(ArpsAward arpsAward)
        {
            Conditions.Add(new PhaseNominator(arpsAward.Phase));
        }

        public override ArpsAward Apply(ArpsAward arpsAward)
        {
            arpsAward.Phase = arpsAward.UserSelection == "Approve" ? 
                AwardPhase.ServicingAo :
                arpsAward.UserSelection == "Return" ? 
                AwardPhase.Initiator :
                AwardPhase.End;

            arpsAward.ViewName = "Done";
            arpsAward.UserSelection = string.Empty;

            return arpsAward;
        }
    }
}