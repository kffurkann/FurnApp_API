using System;
using System.Collections.Generic;

#nullable disable

namespace FurnApp_API.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int AddressId { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string HomeNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
