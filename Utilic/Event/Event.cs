namespace GSR.Utilic.Event
{
    /// <summary>
    /// Simple <see cref="IEvent{T}"/> implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Event<T> : IEvent<T> where T : Delegate
    {
        private readonly IList<T> _handlers = new List<T>();



        /// <inheritdoc/>
        public Event(out IList<T> handlers)
        {
            handlers = _handlers;
        } // end Event()



        /// <inheritdoc/>
        public IEvent<T> Subscribe(T handler)
        {
            if (_handlers.Contains(handler))
                throw new ArgumentException("Handler already subscribed.");

            _handlers.Add(handler);
            return this;
        } // end Subscribe()

        /// <inheritdoc/>
        public IEvent<T> Unsubscribe(T handler)
        {
            if (!_handlers.Contains(handler))
                throw new ArgumentException("Handler not subscribed.");

            _handlers.Remove(handler);
            return this;
        } // end Unsubscribe()



        /// <summary>
        /// Subscribe an event handler to the event.
        /// </summary>
        public static Event<T> operator +(Event<T> e, T handler) => (Event<T>)(((IEvent<T>)e) + handler);

        /// <summary>
        /// Unsubscribe an event handler from the event.
        /// </summary>
        public static Event<T> operator -(Event<T> e, T handler) => (Event<T>)(((IEvent<T>)e) - handler);

    } // end class
} // end namespace