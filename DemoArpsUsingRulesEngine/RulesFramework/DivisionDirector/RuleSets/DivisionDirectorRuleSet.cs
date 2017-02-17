using DemoArps_Models;
using DemoArpsUsingRulesEngine.RulesFramework.DivisionDirector.Rules;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.DivisionDirectorRuleSet.RuleSets
{
    public class DivisionDirectorRuleSet : RuleSet<ArpsAward>
    {
        public DivisionDirectorRuleSet()
            : base()
        {
            Rules.Add(new DivisionDirectorSelectionRule());
            Rules.Add(new DivisionDirectorAmountGreaterThan5000Rule());
        }
    }
}