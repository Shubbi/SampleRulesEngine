using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRulesEngine
{
    public class GenericCondition<T>
    {
        private readonly  Func<T, bool> _methodFunc;

        public GenericCondition(Func<T, bool> methodFunc)
        {
            _methodFunc = methodFunc;
        }

        public bool IsSuccess(T t)
        {
            return _methodFunc.Invoke(t);
        }
    }
}
