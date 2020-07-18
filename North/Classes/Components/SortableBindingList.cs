using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace North.Classes.Components
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool IsSorted { get; set; }
        private ListSortDirection SortDirection { get; set; }
        private PropertyDescriptor SortProperty { get; set; }
        protected override bool SupportsSortingCore => true;

        protected override ListSortDirection SortDirectionCore => SortDirection;

        protected override PropertyDescriptor SortPropertyCore => SortProperty;

        protected override void ApplySortCore(PropertyDescriptor descriptor, ListSortDirection direction)
        {
            if (!(Items is List<T> items))
            {
                IsSorted = false;
            }
            else
            {
                PCompare<T> pCom = new PCompare<T>(descriptor.Name, direction);
                items.Sort(pCom);
                IsSorted = true;
                SortDirection = direction;
                SortProperty = descriptor;
            }

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));

        }
        protected override bool IsSortedCore => IsSorted;
        protected override void RemoveSortCore() => IsSorted = false;

        #region  Constructors 
        public SortableBindingList(ICollection<T> list) : base((IList<T>)list)
        {
        }
        public SortableBindingList() : base()
        {
        }
        #endregion
        #region  Property comparer 
        private class PCompare<T> : IComparer<T>
        {
            private PropertyInfo PropInfo { get; set; }
            private ListSortDirection SortDir { get; set; }
            internal PCompare(string sortProperty, ListSortDirection sortDirection)
            {
                PropInfo = typeof(T).GetProperty(sortProperty);
                SortDir = sortDirection;
            }
            public int Compare(T value1, T value2)
            {

                return
                (
                    (SortDir == ListSortDirection.Ascending) ?
                        Comparer.Default.Compare(PropInfo.GetValue(value1, null), PropInfo.GetValue(value2, null)) :
                        Comparer.Default.Compare(PropInfo.GetValue(value2, null), PropInfo.GetValue(value1, null))
                );

            }
        }
        #endregion
    }
}