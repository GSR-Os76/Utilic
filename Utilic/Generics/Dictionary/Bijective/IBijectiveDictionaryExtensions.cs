namespace GSR.Utilic.Generic
{
    /// <summary>
    /// Extension methods related to <see cref="IBijectiveDictionary{TKey1, TKey2}"/>s.
    /// </summary>
    public static class IBijectiveDictionaryExtensions
    {
        /// <summary>
        /// Create a mutable <see cref="IBijectiveDictionary{TKey1, TKey2}"/> containg the <see cref="KeyValuePair"/>s.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <param name="kvps"></param>
        /// <returns></returns>
        public static IBijectiveDictionary<TKey1, TKey2> ToBijectiveDictionary<TKey1, TKey2>(this IEnumerable<KeyValuePair<TKey1, TKey2>> kvps)
        where TKey1 : notnull
        where TKey2 : notnull
            => new BijectiveDictionary<TKey1, TKey2>(kvps);

        /// <summary>
        /// Create an immutable <see cref="IBijectiveDictionary{TKey1, TKey2}"/> containg the <see cref="KeyValuePair"/>s.
        /// </summary>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <param name="kvps"></param>
        /// <returns></returns>
        public static IBijectiveDictionary<TKey1, TKey2> ToImmutableBijectiveDictionary<TKey1, TKey2>(this IEnumerable<KeyValuePair<TKey1, TKey2>> kvps)
        where TKey1 : notnull
        where TKey2 : notnull
            => new ImmutableBijectiveDictionary<TKey1, TKey2>(kvps);

    } // end class
} // end namespace