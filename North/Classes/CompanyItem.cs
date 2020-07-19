using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace North.Classes
{
    public class CompanyItem
    {
        /// <summary>
        /// Index in list matches row index in DataGridView
        /// </summary>
        /// <returns></returns>
        public int RowIndex { get; set; }
        public CustomerEntity Entity { get; set; }
    }

}
