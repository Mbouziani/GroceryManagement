using System;
using System.Collections.Generic;

namespace GroceryManagement.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int? ProductId { get; set; }
        public int? ReciepId { get; set; }
        public int? SaleQuntity { get; set; }
        public double? SaleTotalPrice { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Reciep? Reciep { get; set; }
    }
}
