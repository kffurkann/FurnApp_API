using System;
using System.Collections.Generic;

#nullable disable

namespace FurnApp_API.Models
{
    public partial class Color
    {
        public Color()
        {
            ProductColors = new HashSet<ProductColor>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; }

        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}
