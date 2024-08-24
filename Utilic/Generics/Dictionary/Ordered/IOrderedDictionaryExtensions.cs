using GSR.Utilic.Generic;

namespace GSR.Utilic.Generics.Dictionary.Ordered
{
    /// <summary>
    /// Extension methods related to <see cref="IOrderedDictionary{TKey, TValue}"/>s.
    /// </summary>
    public static class IOrderedDictionaryExtensions
    {
        /// <summary>
        /// Create a mutable <see cref="IOrderedDictionary{TKey, TValue}"/> containg the <see cref="KeyValuePair"/>s.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="kvps"></param>
        /// <returns></returns>
        public static IOrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> kvps) => new OrderedDictionary<TKey, TValue>(kvps);

        /// <summary>
        /// Create an immutable <see cref="IOrderedDictionary{TKey, TValue}"/> containg the <see cref="KeyValuePair"/>s.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="kvps"></param>
        /// <returns></returns>
        public static IOrderedDictionary<TKey, TValue> ToImmutableOrderedDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> kvps) => new ImmutableOrderedDictionary<TKey, TValue>(kvps);


    } // end class
} // end namespace