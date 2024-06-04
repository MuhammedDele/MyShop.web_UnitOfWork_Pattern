using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repository
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ShoppingContext shoppingContext) : base(shoppingContext)
        {
        }
        public override IEnumerable<Order> All()
        {
            var order = _shoppingContext.Orders.Include(order => order.Orderlines)
                                                .ThenInclude(lineItem => lineItem.Product);
            return order.ToList();
        }
        public override Order Update(Order entity)
        {
            var order = _shoppingContext.Orders.Include(_order => _order.Orderlines)
                                                .ThenInclude(_order => _order.Product)
                                                .Single(o => o.OrderID == entity.OrderID);
            order.OrderDate = entity.OrderDate;
            order.Orderlines = entity.Orderlines;
            return base.Update(order);
        }
    }
}
