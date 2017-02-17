using DemoArps_Common;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.ServicingAo.Conditions
{
    public class PhaseServicingAo : ICondition
    {
        private readonly string _phase;

        public PhaseServicingAo(string phase)
        {
            _phase = phase;
        }

        public bool IsSatisfied()
        {
            return _phase == AwardPhase.ServicingAo;
        }
    }
}