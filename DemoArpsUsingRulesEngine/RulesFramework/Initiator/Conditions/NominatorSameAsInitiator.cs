using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Initiator.Conditions
{
    public class NominatorSameAsInitiator : ICondition
    {
        private readonly string _nominatorSso;
        private readonly string _initiatorSso;

        public NominatorSameAsInitiator(string nominatorSso, string initiatorSso)
        {
            _nominatorSso = nominatorSso;
            _initiatorSso = initiatorSso;
        }

        public bool IsSatisfied()
        {
            return _nominatorSso == _initiatorSso;
        }
    }
}