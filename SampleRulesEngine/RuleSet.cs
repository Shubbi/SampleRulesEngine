using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRulesEngine
{
    public class RuleSet<T>
    {
        private readonly List<IRule<T>> _rules;

        public RuleSet()
        {
            _rules = new List<IRule<T>>();
        }

        public List<IRule<T>> Rules
        {
            get { return _rules; }
        }
    }
}
