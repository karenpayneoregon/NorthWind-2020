using System.Windows.Forms;
using North.Classes.Projections;

namespace North.LanguageExtensions
{
    public static class BindingSourceExtensions
    {
        public static CustomerItem CurrentCustomerItem(this BindingSource sender) => (CustomerItem)sender.Current;
    }
}