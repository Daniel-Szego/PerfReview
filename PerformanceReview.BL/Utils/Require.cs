using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.Utils
{
    /// <summary>
    /// Utility for validation
    /// </summary>
    public static class Require
    {
        public static IArgument<T> Argument<T>(T argument)
        {
            return new Argument<T>(argument);
        }


    }
}
