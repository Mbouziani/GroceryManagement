using System;
using System.Collections.Generic;

namespace GroceryManagement.Models
{
    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? ProductPrice { get; set; }
        public long? ProductBarcode { get; set; }
        public string? ProductImageLink { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
