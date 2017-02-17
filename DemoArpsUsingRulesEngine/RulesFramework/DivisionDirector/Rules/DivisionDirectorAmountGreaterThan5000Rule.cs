using DemoArps.RulesFramework;
using DemoArps_Common;
using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.DivisionDirector.Conditions;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.DivisionDirector.Rules
{
    public class DivisionDirectorAmountGreaterThan5000Rule : BaseRule<ArpsAward>
    {
        public override void Initialize(ArpsAward arpsAward)
        {
            Conditions.Add(new AmountGreaterThan5000(arpsAward.CashAmount));
        }

        public override ArpsAward Apply(ArpsAward arpsAward)
        {
            //This rule runs after DivisionDirectorSelection rule
            //So user selection is already checked and phase is assigned as Ohr
            arpsAward.Phase = arpsAward.Phase == AwardPhase.Ohr ?
                AwardPhase.Ddsm :
                arpsAward.Phase;            

            return arpsAward;
        }
    }
}