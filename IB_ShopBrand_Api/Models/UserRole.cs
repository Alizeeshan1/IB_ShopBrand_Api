using System;
using System.Collections.Generic;

#nullable disable

namespace IB_ShopBrand_Api.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            IbsUsers = new HashSet<IbsUser>();
        }

        public int RoleId { get; set; }
        public string RoleTitle { get; set; }

        public virtual ICollection<IbsUser> IbsUsers { get; set; }
    }
}
