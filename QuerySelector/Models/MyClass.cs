using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuerySelector.Models
{
    public class MyClass
    {
        public int StockId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> ProductQty { get; set; }
        public Nullable<float> Productprice { get; set; }
        public DateTime? StockDate { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public  string ProductManufacture { get; set; }
    }
}