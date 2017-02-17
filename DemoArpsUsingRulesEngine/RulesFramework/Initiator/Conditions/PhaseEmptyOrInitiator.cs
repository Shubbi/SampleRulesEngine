using DemoArps_Common;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Initiator.Conditions
{
    public class PhaseEmptyOrInitiator : ICondition
    {
        private readonly string _phase;

        public PhaseEmptyOrInitiator(string phase)
        {
            _phase = phase;
        }

        public bool IsSatisfied()
        {
            return string.IsNullOrWhiteSpace(_phase)
                || _phase == AwardPhase.Initiator;
        }
    }
}