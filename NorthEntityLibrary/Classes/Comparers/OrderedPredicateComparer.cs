using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthEntityLibrary.Classes.Comparers
{
    public class OrderedPredicateComparer<T> : IComparer<T>
    {
        private readonly Func<T, bool>[] _ordinals;
        public OrderedPredicateComparer(IEnumerable<Func<T, bool>> predicates)
        {
            _ordinals = predicates.ToArray();
        }

        public int Compare(T item1, T item2) => 
            GetOrdinal(item1) - GetOrdinal(item2);

        private int GetOrdinal(T item)
        {
            for (int index = 0; index < _ordinals.Length; index++)
            {
                if (_ordinals[index](item))
                {
                    return index - _ordinals.Length;
                }
            }
            return 0;
        }
    }

}
