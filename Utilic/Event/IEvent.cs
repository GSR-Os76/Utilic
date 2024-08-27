namespace GSR.Utilic.Event
{
    /// <summary>
    /// Contract for a generic event
    /// </summary>
    /// <typeparam name="T">The handler type.</typeparam>
    public interface IEvent<T> where T : Delegate
    {
        /// <summary>
        /// Subscribe an event handler to the event.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>Self.</returns>
        public IEvent<T> Subscribe(T handler);

        /// <summary>
        /// Unsubscribe an event handler to the event.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>Self.</returns>
        public IEvent<T> Unsubscribe(T handler);



        /// <summary>
        /// Subscribe an event handler to the event.
        /// </summary>
        public static IEvent<T> operator +(IEvent<T> e, T handler) => e.Subscribe(handler);

        /// <summary>
        /// Unsubscribe an event handler from the event.
        /// </summary>
        public static IEvent<T> operator -(IEvent<T> e, T handler) => e.Unsubscribe(handler);

    } // end class
} // end namespace