using System;
using System.Collections.Generic;

#nullable disable

namespace FurnApp_API.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? CargoNo { get; set; }
        public int? UsersId { get; set; }
        public int? ProductId { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Product Product { get; set; }
        public virtual User Users { get; set; }
    }
}
