using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Domain.Models
{
	public class Order
	{
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<Orderline>? Orderlines { get; set; }
        public Customer? Customer { get; set; }

        public decimal OrderTotal => Orderlines.Sum(item => item.Product.Price * item.Quantity);
    }
}
