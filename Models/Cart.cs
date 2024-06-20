using System;
using System.Collections.Generic;

#nullable disable

namespace FurnApp_API.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int? UsersId { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User Users { get; set; }
    }
}
