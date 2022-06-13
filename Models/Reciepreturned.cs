using System;
using System.Collections.Generic;

namespace GroceryManagement.Models
{
    public partial class Reciepreturned
    {
        public int ReciepId { get; set; }
        public long? ReciepNumber { get; set; }
        public int? ReciepProductCount { get; set; }
        public double? ReciepTotalPrice { get; set; }
        public double? RecieppriceTax { get; set; }
        public double? PriceTotalWithTax { get; set; }
        public string? ReciepDate { get; set; }
        public string? ReturnedDate { get; set; }
    }
}
