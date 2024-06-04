using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyShop.Domain.Models
{
	public class Customer
	{
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string? ShippingAddress { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

    }
}
