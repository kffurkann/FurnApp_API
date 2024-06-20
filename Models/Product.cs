using System;
using System.Collections.Generic;

#nullable disable

namespace FurnApp_API.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            ProductColors = new HashSet<ProductColor>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductStock { get; set; }
        public decimal? ProductPrice { get; set; }
        public byte[] ProductPicture { get; set; }
        public string ProductDescription { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}
