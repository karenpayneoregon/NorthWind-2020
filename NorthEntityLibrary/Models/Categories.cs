using System.Collections.Generic;
using North.Interfaces;
using NorthClassLibrary.Models;

namespace NorthEntityLibrary.Models
{
    public partial class Categories : IModelBaseEntity
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int Id => CategoryID;
        /// <summary>
        /// Primary key
        /// </summary>
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}