using System;
using System.Collections.Generic;

#nullable disable

namespace IB_ShopBrand_Api.Models
{
    public partial class IbsUser
    {
        public int UserUnique { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string UserMobile { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string UserActive { get; set; }
        public string UserPic { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UserSource { get; set; }
        public string InsertBy { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string UserPassword { get; set; }
        public string Token { get; set; }

        public virtual UserRole Role { get; set; }
    }
}
