using GSR.Utilic.Generic;

namespace GSR.Utilic.Event
{
    /// <summary>
    /// Simple <see cref="IKeyedEvent{TKey, THandler}"/> implemenation.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TDelegate"></typeparam>
    public class FixedKeysKeyedEvent<TKey, TDelegate> : IKeyedEvent<TKey, TDelegate>
        where TDelegate : Delegate
        where TKey : notnull
    {
        private readonly IDictionary<TKey, IEvent<TDelegate>> _events = new Dictionary<TKey, IEvent<TDelegate>>();
        private readonly IDictionary<TKey, IList<TDelegate>> _handlers = new Dictionary<TKey, IList<TDelegate>>();



        /// <inheritdoc/>
        public FixedKeysKeyedEvent(IEnumerable<TKey> keys, out IDictionary<TKey, IList<TDelegate>> handlers)
        {
            if (keys.AnyRepeats())
                throw new ArgumentException("Duplicate key encountered.");

            keys.ForEach((x) => AddKey(x));
            handlers = _handlers;
        } // end constructor



        /// <inheritdoc/>
        public IEvent<TDelegate> this[TKey key]
        {
            get
            {
                if (!_events.ContainsKey(key))
                    throw new KeyNotFoundException($"No event for the key: \"{key}\"");

                return _events[key];
            }
            set { }
        } // end indexer

        private void AddKey(TKey key)
        {
            _events[key] = new Event<TDelegate>(out IList<TDelegate> x);
            _handlers[key] = x;
        }

    } // end class
} // end namespace