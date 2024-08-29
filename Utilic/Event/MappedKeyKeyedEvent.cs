namespace GSR.Utilic.Event
{
    /// <summary>
    /// Implementation of <see cref="IKeyedEvent{TKey, THandler}"/> that maps it's key to a key in another internal <see cref="ILookup{TKey, TElement}"/>.
    /// </summary>
    /// <typeparam name="TOuterKey"></typeparam>
    /// <typeparam name="TInnerKey"></typeparam>
    /// <typeparam name="THandler"></typeparam>
    public class MappedKeyKeyedEvent<TOuterKey, TInnerKey, THandler> : IKeyedEvent<TOuterKey, THandler>
        where THandler : Delegate
        where TOuterKey : notnull
        where TInnerKey : notnull
    {
        /// <inheritdoc/>
        public IEvent<THandler> this[TOuterKey key] 
        {
            get => _internal[_mapper.Invoke(key)];
            set => _internal[_mapper.Invoke(key)] = value; 
        }



        private readonly IKeyedEvent<TInnerKey, THandler> _internal;
        private readonly Func<TOuterKey, TInnerKey> _mapper;



        /// <inheritdoc/>
        public MappedKeyKeyedEvent(IKeyedEvent<TInnerKey, THandler> @internal, Func<TOuterKey, TInnerKey> mapper)
        {
            _internal = @internal.IsNotNull();
            _mapper = mapper.IsNotNull();
        } // end constructor()

    } // end class
} // end namespace