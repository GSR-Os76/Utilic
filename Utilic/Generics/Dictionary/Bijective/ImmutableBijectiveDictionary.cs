using System.Collections.Immutable;

namespace GSR.Utilic.Generic
{
    /// <summary>
    /// Immutable <see cref="IBijectiveDictionary{TKey1, TKey2}"/> implementation.
    /// </summary>
    /// <typeparam name="TKey1"></typeparam>
    /// <typeparam name="TKey2"></typeparam>
    public sealed class ImmutableBijectiveDictionary<TKey1, TKey2> : ABijectiveDictionary<TKey1, TKey2>
        where TKey1 : notnull
        where TKey2 : notnull
    {
        /// <inheritdoc/>
        public ImmutableBijectiveDictionary(IEnumerable<KeyValuePair<TKey1, TKey2>> pairs) : base(pairs.ToImmutableDictionary()) { } // end constructor

        /// <inheritdoc/>
        public ImmutableBijectiveDictionary() : base(ImmutableDictionary<TKey1, TKey2>.Empty) { } // end constructor

    } // end class
} // end namespace