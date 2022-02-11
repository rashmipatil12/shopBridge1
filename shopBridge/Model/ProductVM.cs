using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopBridge.Model
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public double? ProductPrice { get; set; }
    }
}
