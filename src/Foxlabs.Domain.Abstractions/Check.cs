using System;
using System.Collections.Generic;
using System.Linq;

namespace FoxLabs
{
    /// <summary>
    /// A class of various static methods useful in providing
    /// quick and inline capable guards for parameters.
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Check if the string parameter is not empty, but can be null.
        /// </summary>
        public static string NotEmpty(string value, string parameterName)
        {
            if (value == null) 
            {
                return null;
            }

            if (value.Length == 0) 
            {
                throw new ArgumentException("String cannot be empty.", parameterName);
            }

            return value;
        }

        /// <summary>
        /// Check if the string parameter is not empty or null.
        /// </summary>
        public static string NotEmptyOrNull(string value, string parameterName)
        {
            if (value == null) 
            {
                throw new ArgumentNullException(parameterName);
            }

            if (value.Length == 0) 
            {
                throw new ArgumentException("String cannot be empty.", parameterName);
            }

            return value;
        }

        /// <summary>
        /// Check if the collection parameter is not empty, but can be null.
        /// </summary>
        public static IEnumerable<T> NotEmpty<T>(IEnumerable<T> list, string parameterName)
        {
            if (list == null) 
            {
                return null;
            }

            if (list.Count() == 0)
            {
                throw new ArgumentException("List cannot be empty.", parameterName);
            }

            return list;
        }

        /// <summary>
        /// Check if the collection parameter is not empty or null.
        /// </summary>
        public static IEnumerable<T> NotEmptyOrNull<T>(IEnumerable<T> list, string parameterName)
        {
            if (list == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (list.Count() == 0)
            {
                throw new ArgumentException("List cannot be empty.", parameterName);
            }

            return list;
        }

        /// <summary>
        /// Check if the parameter is not null.
        /// </summary>
        public static T NotNull<T>(T value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }
    }
}