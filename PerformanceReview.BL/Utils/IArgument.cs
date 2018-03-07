using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.Utils
{
    /// <summary>
    /// An argument
    /// </summary>
    /// <typeparam name="T">Argument Type</typeparam>
    public interface IArgument<T>
    {
        T Value { get; }
    }
}
