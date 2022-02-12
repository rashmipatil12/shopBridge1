using System;
using System.Collections.Generic;

namespace shopBridge.Model
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public double? ProductPrice { get; set; }
        public bool? IsActive { get; set; }
    }
}
