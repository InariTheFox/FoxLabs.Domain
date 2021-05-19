using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FoxLabs.Domain
{
    /// <summary>
    /// The base class for defining an enumeration.
    /// </summary>
    /// <remarks>
    /// Defining elements of an enumeration is accomplished by declaring a static field of the enumeration in the
    /// derived class.
    /// <para>
    /// <code>
    /// public class Foo : Enumeration
    /// {
    ///     public static Foo Bar = new Foo(0, "Bar");
    ///     public static Foo Baz = new Foo(1, "Baz");
    ///
    ///     ...
    ///
    /// }
    /// </code>
    /// </para>
    /// </remarks>
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        /// Gets the name of the enumerable item.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the identifier of the enumerable item.
        /// </summary>
        public int Id { get; private set; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        /// <summary>
        /// Returns all enumerable items for this enumeration.
        /// </summary>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        /// <inheritdoc />
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        /// Returns the absolute difference between the two specified enumerable items and their identifiers.
        /// </summary>
        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
            => Math.Abs(firstValue.Id - secondValue.Id);

        /// <summary>
        /// Compares the current enumerable item to the other specified item.
        /// </summary>
        public int CompareTo(object other) 
            => Id.CompareTo(((Enumeration)other).Id);

        /// <summary>
        /// Returns the enumerable item from the identifier specified.
        /// </summary>
        public static T FromValue<T>(int value) where T : Enumeration
            => Parse<T, int>(value, "value", item => item.Id == value);

        /// <summary>
        /// Returns the enumerable item from the name specified.
        /// </summary>
        public static T FromDisplayName<T>(string displayName) where T : Enumeration
            => Parse<T, string>(displayName, "display name", item => item.Name == displayName);

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
            }

            return matchingItem;
        }
    }
}