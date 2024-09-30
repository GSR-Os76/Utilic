namespace GSR.Utilic.Indexer
{
    /// <summary>
    /// Contract for an indexer allowing access to some collection.
    /// </summary>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTo"></typeparam>
    public interface IIndexer<TFrom, TTo>
    {
        /// <summary>
        /// Access to <typeparamref name="TTo"/> associated with the <typeparamref name="TFrom"/>.
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public TTo this[TFrom from] { get; }
    } // end class
} // end namespace