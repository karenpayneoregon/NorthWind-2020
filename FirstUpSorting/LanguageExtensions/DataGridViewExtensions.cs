using System.Windows.Forms;

namespace FirstUpSorting.LanguageExtensions
{
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Expand all columns and suitable for working with
        /// Entity Framework
        /// </summary>
        /// <param name="sender">Valid DataGridView with no unbound columns that have null values</param>
        public static void ExpandColumns(this DataGridView sender, string replace = null)
        {
            if (!string.IsNullOrWhiteSpace(replace))
            {
                foreach (DataGridViewColumn col in sender.Columns)
                {
                    col.HeaderText = col.HeaderText.Replace(replace, "");
                }
            }

            foreach (DataGridViewColumn col in sender.Columns)
            {
                if (col.ValueType.Name != "ICollection`1")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

    }
}
