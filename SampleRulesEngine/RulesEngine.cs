using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRulesEngine
{
    public static class RulesEngine
    {
        public static T ApplyRule<T>(this T obj, IRule<T> rule) where T : class
        {
            rule.ClearConditions();
            rule.Initialize(obj);

            if (rule.IsValid())
            {
                rule.Apply(obj);
            }

            return obj;
        }

        public static T RunRuleSet<T>(this T obj, RuleSet<T> ruleSet) where T : class
        {
            foreach (var rule in ruleSet.Rules)
            {
                obj.ApplyRule(rule);
            }

            return obj;
        }
    }
}
