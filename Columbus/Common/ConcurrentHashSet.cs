using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Columbus.Common
{
    public class ConcurrentHashSet<T>
    {
        private readonly ConcurrentDictionary<T, byte> _dictionary;
        public int Count => _dictionary.Count;

        public ConcurrentHashSet(IEqualityComparer<T> comparer)
        {
            _dictionary = new ConcurrentDictionary<T, byte>(comparer);
        }

        public bool TryAdd(T item)
        {
            return _dictionary.TryAdd(item, 0);
        }

        public bool TryRemove(T item)
        {
            return _dictionary.TryRemove(item, out _);
        }
    }
}
