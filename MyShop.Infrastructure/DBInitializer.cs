using MyShop.Domain.Models;
using System;
using System.Linq;

namespace MyShop.Infrastructure
{

    public class DBInitializer
    {
        public static void Initialize(ShoppingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                new Product { Name = "Canon EOS 70D", Price = 599m },
                new Product { Name = "Shure SM7B", Price = 245m },
                new Product { Name = "Key Light", Price = 59.99m },
                new Product { Name = "Android Phone", Price = 259.59m },
                new Product { Name = "5.1 Speaker System", Price = 799.99m });
            context.SaveChanges();

            context.Customers.AddRange(
                new Customer
                {
                    Name = "Harry Page",
                    ShippingAddress = "217 E Center Street",
                    City = "Moab",
                    PostalCode = "UT 84532",
                    Country = "US"
                },
                new Customer
                {
                    Name = "Nancy Jones",
                    ShippingAddress = "200 W. Railroad Ave",
                    City = "Williams",
                    PostalCode = "AZ 86046",
                    Country = "US"
                });
            context.SaveChanges();

            context.Orders.AddRange(
                new Order
                {
                    CustomerID = 1,
                    OrderDate = DateTime.Now
                });
            context.SaveChanges();

            context.Orderlines.AddRange(
                 new Orderline
                 {
                     OrderID = 1,
                     ProductID = 1,
                     Quantity = 1
                 },
                 new Orderline
                 {
                     OrderID = 1,
                     ProductID = 3,
                     Quantity = 2
                 },
                 new Orderline
                 {
                     OrderID = 1,
                     ProductID = 4,
                     Quantity = 1
                 });
            context.SaveChanges();
        }
    }
}
