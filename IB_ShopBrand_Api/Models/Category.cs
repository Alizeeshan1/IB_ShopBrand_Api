using System;
using System.Collections.Generic;

#nullable disable

namespace IB_ShopBrand_Api.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string Active { get; set; }
        public string Token { get; set; }
    }
}
