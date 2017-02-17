using DemoArps_Common;
using SampleRulesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoArpsUsingRulesEngine.RulesFramework.DivisionDirector.Conditions
{
    public class AmountGreaterThan5000 : ICondition
    {
        private readonly decimal _amount;

        public AmountGreaterThan5000(decimal amount)
        {
            _amount = amount;
        }

        public bool IsSatisfied()
        {
            return _amount > 5000.0m;
        }
    }
}