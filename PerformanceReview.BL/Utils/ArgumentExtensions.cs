﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.Utils
{
    /// <summary>
    /// Extension methods for guarding
    /// </summary>
    public static class ArgumentExtensions
    {

        /// <summary>
        /// Throws an ArgumentNullException if argument is null
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        /// <param name="argument">Argument to check</param>
        /// <param name="argumentName">parameter/argument name</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IsNotNull<T>(this IArgument<T> argument, string argumentName)
            where T : class
        {
            argumentName = string.IsNullOrEmpty(argumentName) ? "value" : argumentName;
            if (argument.Value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the string argument is null or empty
        /// </summary>
        /// <param name="argument">Argument to check</param>
        /// <param name="argumentName">parameter/argument name</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void IsNotNullOrEmpty(this IArgument<string> argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument.Value))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException if the value of the argument is out of the supplied range
        /// </summary>
        /// <typeparam name="T">Type implementing <see cref="IComparable"/></typeparam>
        /// <param name="argument">The argument to check</param>
        /// <param name="min">Min value of the supplied range</param>
        /// <param name="max">Max value of the supplied range</param>
        /// <param name="argumentName">parameter/argument name</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void IsInRange<T>(this IArgument<T> argument, T min, T max, string argumentName)
            where T : IComparable
        {
            if (!(argument.Value.CompareTo(min) >= 0 && argument.Value.CompareTo(max) <= 0))
            {
                throw new ArgumentOutOfRangeException(argumentName);
            }
        }
    }
}
