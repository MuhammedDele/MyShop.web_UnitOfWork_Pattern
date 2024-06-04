using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Models
{
	public class Orderline
	{
        public int OrderlineID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public Product? Product { get; set; }
        public Order? Order { get; set; }
    }
}
