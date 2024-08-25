namespace GSR.Utilic
{
    /// <summary>
    /// Exception that occurs when a predicted as impossible state is reached.
    /// </summary>
    [Serializable]
    public class UnexpectedStateException : Exception
    {
        /// <inheritdoc/>
        public UnexpectedStateException() { }
        /// <inheritdoc/>
        public UnexpectedStateException(string message) : base(message) { }
        /// <inheritdoc/>
        public UnexpectedStateException(string message, Exception inner) : base(message, inner) { }
        /// <inheritdoc/>
        protected UnexpectedStateException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    } // end class
} // end namespace