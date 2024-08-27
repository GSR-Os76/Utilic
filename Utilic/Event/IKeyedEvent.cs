namespace GSR.Utilic.Event
{
    /// <summary>
    /// Contract for an event that fires at different times based on a key.
    /// </summary>
    public interface IKeyedEvent<TKey, THandler>
        where THandler : Delegate
        where TKey : notnull
    {
        /// <summary>
        /// Get the event for the given key. Set for convenience, has no obligation to perform any behavior.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEvent<THandler> this[TKey key] { get; set; }
    } // end interface
} // end namespace