using System;
using System.Collections.Generic;

#nullable disable

namespace IB_ShopBrand_Api.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductModel { get; set; }
        public string ProductColour { get; set; }
    }
}
