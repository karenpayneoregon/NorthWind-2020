using System;
using NorthEntityLibrary.Classes.Comparers;

namespace NorthEntityLibrary.Classes
{
    public class SpecificOrdering : OrderedPredicateComparer<string>
    {
        private static readonly Func<string, bool>[] Order =
        {
            (value) => value.StartsWith("Bon"),
            (item) => item.StartsWith("Cac"),
            (item) => item.StartsWith("Du")
        };

        public SpecificOrdering() : base(Order)
        {
        }
    }

}
