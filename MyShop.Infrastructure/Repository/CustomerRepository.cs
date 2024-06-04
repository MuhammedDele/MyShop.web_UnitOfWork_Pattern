using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext shoppingContext) : base(shoppingContext)
        {
        }
        public override Customer Update(Customer entity)
        {
            var customer = _shoppingContext.Customers.Single( c => c.CustomerID == entity.CustomerID );
            customer.Name = entity.Name;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.City = entity.City;
            customer.Country = entity.Country;
            customer.PostalCode = entity.PostalCode;
            return base.Update(customer);
        }
    }
}
