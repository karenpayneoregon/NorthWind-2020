using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace North.LanguageExtensions
{
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Expand all columns and suitable for working with
        /// Entity Framework
        /// </summary>
        /// <param name="sender">Valid DataGridView with no unbound columns that have null values</param>
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                // ensure we are not attempting to do this on a Entity
                if (col.ValueType.Name != "ICollection`1")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

    }
}
