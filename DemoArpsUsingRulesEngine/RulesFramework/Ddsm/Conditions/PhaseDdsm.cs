using DemoArps_Common;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.Ddsm.Conditions
{
    public class PhaseDdsm : ICondition
    {
        private readonly string _phase;

        public PhaseDdsm(string phase)
        {
            _phase = phase;
        }

        public bool IsSatisfied()
        {
            return _phase == AwardPhase.Ddsm;
        }
    }
}