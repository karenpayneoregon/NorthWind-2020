using NorthWindCore.Interfaces;

namespace NorthWindCore.Models
{
    public partial class OrderDetails : IModelBaseEntity
    {
        public int Id => OrderID;
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}