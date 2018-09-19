namespace StaySharp.JavaUtils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     The C# Implementation of Javas Objects Util class. Provides object level methods
    ///     to perform null safe or null tolerant operations.
    ///     <see href="https://docs.oracle.com/javase/7/docs/api/java/util/Objects.html" />
    /// </summary>
    public static class Objects
    {
        /// <summary>
        ///     Checks that the specified object reference is not null.
        ///     This method is designed primarily for doing parameter validation in methods and constructors.
        /// </summary>
        /// <typeparam name="T">the type of the reference</typeparam>
        /// <param name="object">the object reference to check for nullity</param>
        /// <param name="message">
        ///     alternative detail message to be used in the event
        ///     that a <see cref="ArgumentNullException" /> is thrown
        /// </param>
        /// <returns>@object if not null</returns>
        public static T RequireNonNull<T>(this T @object, string message = "")
        {
            if (@object == null) throw new ArgumentNullException(message);

            return @object;
        }

        /// <summary>
        ///     Returns 0 if the arguments are identical and comparer.Compare(objA, objB) otherwise.
        ///     Consequently, if both arguments are null 0 is returned.
        /// </summary>
        /// <typeparam name="T">the type of the objects being compared</typeparam>
        /// <param name="objA">an object</param>
        /// <param name="objB">an object to be compared with a</param>
        /// <param name="comparer">the <see cref="Comparer{T}" /> to compare the first two arguments</param>
        /// <returns>0 if the arguments are identical and comparer.Compare(objA, objB) otherwise.</returns>
        public static int Compare<T>(this T objA, T objB, Comparer<T> comparer) where T : class
        {
            return objA == objB ? 0 : comparer.Compare(objA, objB);
        }

        /// <summary>
        ///     Returns true if the arguments are deeply equal to each other and false otherwise.
        ///     Two null values are deeply equal.
        ///     If both arguments are arrays, an special Array algorithm determine equality.
        ///     Otherwise, equality is determined by using the equals method of the first argument.
        /// </summary>
        /// <typeparam name="T">the type of the objects being compared</typeparam>
        /// <param name="objA">an object</param>
        /// <param name="objB">an object to be compared with a for deep equality</param>
        /// <returns>true if the arguments are deeply equal to each other and false otherwise</returns>
        public static bool DeepEquals<T>(this T objA, T objB) where T : class
        {
            if (objA == objB) return objA == objB;

            if (objA == null || objB == null) return false;

            if (!(objA is IEnumerable<T> objAEnumerable)) return false;

            if (!(objB is IEnumerable<T> objBEnumerable)) return false;

            return objAEnumerable.SequenceEqual(objBEnumerable);
        }

        /// <summary>
        ///     Returns true if the arguments are equal to each other and false otherwise.
        ///     Consequently, if both arguments are null, true is returned and if exactly one argument is null, false is returned.
        ///     Otherwise, equality is determined by using the equals method of the first argument.
        /// </summary>
        /// <param name="objA">an object</param>
        /// <param name="objB">an object to be compared with a for equality</param>
        /// <returns>true if the arguments are equal to each other and false otherwise</returns>
        public static bool NullSafeEquals(this object objA, object objB)
        {
            return objA == objB || objA != null && objA.Equals(objB);
        }

        /// <summary>
        ///     Returns the hash code of a non-null argument and 0 for a null argument.
        /// </summary>
        /// <param name="object">an object</param>
        /// <returns>the hash code of a non-null argument and 0 for a null argument</returns>
        public static int NullSafeHashCode(this object @object)
        {
            return @object?.GetHashCode() ?? 0;
        }

        /// <summary>
        ///     Generates a hash code for a sequence of input values. The hash code is generated as if all
        ///     he input values were placed into an array, and that array were hashed by calling an
        ///     internal Arrays hash algorithm.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int Hash(params object[] values)
        {
            return Arrays.HashCode(values);
        }

        /// <summary>
        ///     Returns the result of calling ToString for a non-null argument and "null" for a null argument.
        /// </summary>
        /// <param name="object">an object</param>
        /// <param name="nullDefault">alternative string to return if the first argument is null</param>
        /// <returns>the result of calling ToString on the first argument if it is not null and the second argument otherwise.</returns>
        public static string NullSaveToString(this object @object, string nullDefault = null)
        {
            nullDefault = nullDefault ?? "null";

            return @object == null ? nullDefault : @object.ToString();
        }
    }
}