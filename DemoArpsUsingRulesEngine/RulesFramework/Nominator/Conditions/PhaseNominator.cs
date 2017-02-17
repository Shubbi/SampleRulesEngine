using DemoArps_Common;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Nominator.Conditions
{
    public class PhaseNominator : ICondition
    {
        private readonly string _phase;

        public PhaseNominator(string phase)
        {
            _phase = phase;
        }

        public bool IsSatisfied()
        {
            return _phase == AwardPhase.Nominator;
        }
    }
}