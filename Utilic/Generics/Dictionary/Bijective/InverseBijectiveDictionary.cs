using GSR.Utilic.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace GSR.Utilic.Generic
{
    /// <summary>
    /// <see cref="IBijectiveDictionary{TKey1, TKey2}"/> that act by inverting an given inner <see cref="IBijectiveDictionary{TKey1, TKey2}"/>.
    /// </summary>
    /// <typeparam name="TKey1"></typeparam>
    /// <typeparam name="TKey2"></typeparam>
    public sealed class InverseBijectiveDictionary<TKey1, TKey2> : IBijectiveDictionary<TKey1, TKey2>
        where TKey1 : notnull
        where TKey2 : notnull
    {
        /// <inheritdoc/>
        public TKey2 this[TKey1 key]
        {
            get => _inner.First((x) => x.Value.Equals(key)).Key;
            set
            {
                TKey2 innerKey = _inner.First((x) => x.Value.Equals(key)).Key;
                // remove from inner were value is key
                if (_inner.ContainsKey(innerKey))
                    _inner.Remove(innerKey);
                // add new pair
                _inner.Add(value, key);
            }
        } // end indexer

        /// <inheritdoc/>
        public IBijectiveDictionary<TKey2, TKey1> I => _inner;

        /// <inheritdoc/>
        public ICollection<TKey1> Keys => _inner.Values;

        /// <inheritdoc/>
        public ICollection<TKey2> Values => _inner.Keys;

        /// <inheritdoc/>
        public int Count => _inner.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => _inner.IsReadOnly;

        private readonly IBijectiveDictionary<TKey2, TKey1> _inner;



        /// <inheritdoc/>
        public InverseBijectiveDictionary(IBijectiveDictionary<TKey2, TKey1> inner)
        {
            _inner = inner.IsNotNull();
        } // end constructor




        /// <inheritdoc/>
        public void Add(TKey1 key, TKey2 value) => _inner.Add(value, key);

        /// <inheritdoc/>
        public void Add(KeyValuePair<TKey1, TKey2> item) => Add(item.Key, item.Value);

        /// <inheritdoc/>
        public void Clear() => _inner.Clear();

        /// <inheritdoc/>
        public bool Contains(KeyValuePair<TKey1, TKey2> item) => _inner.Contains(KeyValuePair.Create(item.Value, item.Key));

        /// <inheritdoc/>
        public bool ContainsKey(TKey1 key) => Keys.Contains(key);

        /// <inheritdoc/>
        public void CopyTo(KeyValuePair<TKey1, TKey2>[] array, int arrayIndex)
            => this.ForEvery((x, i) => array[arrayIndex + i] = x);

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<TKey1, TKey2>> GetEnumerator() => _inner
            .Select((x) => KeyValuePair.Create(x.Value, x.Key)).GetEnumerator();

        /// <inheritdoc/>
        public bool Remove(TKey1 key) => _inner.Remove(_inner.First((x) => x.Value.Equals(key)));

        /// <inheritdoc/>
        public bool Remove(KeyValuePair<TKey1, TKey2> item) => _inner.Remove(KeyValuePair.Create(item.Value, item.Key));

        /// <inheritdoc/>
        public bool TryGetValue(TKey1 key, [MaybeNullWhen(false)] out TKey2 value)
        {
            if (!ContainsKey(key))
            {
                value = default;
                return false;
            }

            value = _inner.First((x) => x.Value.Equals(key)).Key;
            return true;
        } // end TryGetValue()

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    } // end class
} // end namespace