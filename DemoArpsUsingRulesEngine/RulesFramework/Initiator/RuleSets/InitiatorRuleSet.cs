using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.Initiator.Rules;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Initiator.RuleSets
{
    public class InitiatorRuleSet : RuleSet<ArpsAward>
    {
        public InitiatorRuleSet() : base()
        {
            Rules.Add(new NominatorSameAsInitiatorRule());
            Rules.Add(new NominatorDifferentThanInitiatorRule());
        }
    }
}