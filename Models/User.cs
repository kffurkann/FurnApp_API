using System;
using System.Collections.Generic;

#nullable disable

namespace FurnApp_API.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
        }

        public int UsersId { get; set; }
        public string UsersMail { get; set; }
        public string UsersPassword { get; set; }
        public int? UsersAuthorization { get; set; }
        public int? UsersTelNo { get; set; }
        public string UsersAddress { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
