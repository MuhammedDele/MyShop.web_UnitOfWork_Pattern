using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyShop.Domain.Models
{
	public class Product
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}
