using DemoArps_Common;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.DivisionDirector.Conditions
{
    public class PhaseDivisionDirector : ICondition
    {
        private readonly string _phase;

        public PhaseDivisionDirector(string phase)
        {
            _phase = phase;
        }

        public bool IsSatisfied()
        {
            return _phase == AwardPhase.DivisionDirector;
        }
    }
}