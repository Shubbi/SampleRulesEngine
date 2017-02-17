using DemoArps_Models;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Initiator.Conditions
{
    public class NominatorDifferentThanInitiator : ICondition
    {
        private readonly string _nominatorSso;
        private readonly string _initiatorSso;

        public NominatorDifferentThanInitiator(string nominatorSso, string initiatorSso)
        {
            _nominatorSso = nominatorSso;
            _initiatorSso = initiatorSso;
        }

        public bool IsSatisfied()
        {
            return _nominatorSso != _initiatorSso;
        }
    }
}