using System;
using System.Collections.Generic;

#nullable disable

namespace FurnApp_API.Models
{
    public partial class ProductColor
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }

        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
    }
}
