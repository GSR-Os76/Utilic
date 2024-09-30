namespace GSR.Utilic.Generic
{
    /// <summary>
    /// Contract for a bijective <see cref="IDictionary{TKey, TValue}"/>.
    /// </summary>
    /// <typeparam name="TKey1"></typeparam>
    /// <typeparam name="TKey2"></typeparam>
    public interface IBijectiveDictionary<TKey1, TKey2> : IDictionary<TKey1, TKey2>
        where TKey1 : notnull
        where TKey2 : notnull
    {
        /// <summary>
        /// Get an <see cref="IBijectiveDictionary{TKey1, TKey2}"/> with it's key/value access mirrored.
        /// </summary>
        public IBijectiveDictionary<TKey2, TKey1> I { get; }
    } // end class
} // end namespace