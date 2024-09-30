namespace GSR.Utilic.Indexer
{
    /// <summary>
    /// Simple <see cref="IIndexer{TFrom, TTo}"/> implementation.
    /// </summary>
    public sealed class Indexer<TFrom, TTo> : IIndexer<TFrom, TTo>
    {
        /// <inheritdoc/>
        public TTo this[TFrom from] => _indexer.Invoke(from);
        private readonly Func<TFrom, TTo> _indexer;



        public Indexer(Func<TFrom, TTo> indexer) 
        {
            _indexer = indexer.IsNotNull();
        } // end constructor

    } // end class
} // end namespace