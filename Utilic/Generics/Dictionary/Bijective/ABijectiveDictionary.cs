using GSR.Utilic.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace GSR.Utilic.Generic
{
    /// <summary>
    /// <see cref="IBijectiveDictionary{TKey1, TKey2}"/> implementation for wrapping a <see cref="IDictionary{TKey, TValue}"/> implementation, intended as a base class.
    /// </summary>
    /// <typeparam name="TKey1"></typeparam>
    /// <typeparam name="TKey2"></typeparam>
    public abstract class ABijectiveDictionary<TKey1, TKey2> : IBijectiveDictionary<TKey1, TKey2>
        where TKey1 : notnull
        where TKey2 : notnull
    {
        /// <inheritdoc/>
        public TKey2 this[TKey1 key] { get => _inner[key]; set => _inner[key] = value; }

        /// <inheritdoc/>
        public IBijectiveDictionary<TKey2, TKey1> I => _i;

        /// <inheritdoc/>
        public ICollection<TKey1> Keys => _inner.Keys;

        /// <inheritdoc/>
        public ICollection<TKey2> Values => _inner.Values;

        /// <inheritdoc/>
        public int Count => _inner.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => _inner.IsReadOnly;



        private readonly IDictionary<TKey1, TKey2> _inner;
        private readonly IBijectiveDictionary<TKey2, TKey1> _i;


        /// <summary>
        /// Construct as wrapping inner dict.
        /// </summary>
        /// <param name="inner"></param>
        public ABijectiveDictionary(IDictionary<TKey1, TKey2> inner)
        {
            if (inner.IsNotNull().Values.AnyRepeats())
                throw new ArgumentException("Repeated keys found.");

            _inner = inner;
            _i = new InverseBijectiveDictionary<TKey2, TKey1>(this);
        } // end constructor



        /// <inheritdoc/>
        public void Add(TKey1 key, TKey2 value)
        {
            if (Values.Contains(value.IsNotNull()))
                throw new ArgumentException($"An item with the same key has already been added. Key2: {value}");

            _inner.Add(key, value);
        } // end Add()

        /// <inheritdoc/>
        public void Add(KeyValuePair<TKey1, TKey2> item) => _inner.Add(item.Key, item.Value);

        /// <inheritdoc/>
        public void Clear() => _inner.Clear();

        /// <inheritdoc/>
        public bool Contains(KeyValuePair<TKey1, TKey2> item) => _inner.Contains(item);

        /// <inheritdoc/>
        public bool ContainsKey(TKey1 key) => _inner.ContainsKey(key);

        /// <inheritdoc/>
        public void CopyTo(KeyValuePair<TKey1, TKey2>[] array, int arrayIndex) => _inner.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<TKey1, TKey2>> GetEnumerator() => _inner.GetEnumerator();

        /// <inheritdoc/>
        public bool Remove(TKey1 key) => _inner.Remove(key);

        /// <inheritdoc/>
        public bool Remove(KeyValuePair<TKey1, TKey2> item) => _inner.Remove(item);

        /// <inheritdoc/>
        public bool TryGetValue(TKey1 key, [MaybeNullWhen(false)] out TKey2 value) => _inner.TryGetValue(key, out value);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => _inner.GetEnumerator();

    } // end class
} // end namespace