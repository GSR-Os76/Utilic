namespace GSR.Utilic.Generic
{
    /// <summary>
    /// Mutable <see cref="IBijectiveDictionary{TKey1, TKey2}"/> implementation.
    /// </summary>
    /// <typeparam name="TKey1"></typeparam>
    /// <typeparam name="TKey2"></typeparam>
    public sealed class BijectiveDictionary<TKey1, TKey2> : ABijectiveDictionary<TKey1, TKey2>
        where TKey1 : notnull
        where TKey2 : notnull
    {
        /// <inheritdoc/>
        public BijectiveDictionary(IEnumerable<KeyValuePair<TKey1, TKey2>> pairs) : base(pairs.ToDictionary((x) => x.Key, (x) => x.Value)) { } // end constructor

        /// <inheritdoc/>
        public BijectiveDictionary() : base(new Dictionary<TKey1, TKey2>()) { } // end constructor

    } // end class
} // end namespace