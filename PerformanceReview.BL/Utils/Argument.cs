using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.Utils
{
    internal class Argument<T> : IArgument<T>
    {
        public Argument(T @value)
        {
            _value = @value;
        }

        private T _value;

        T IArgument<T>.Value
        {
            get { return _value; }
        }
    }
}
