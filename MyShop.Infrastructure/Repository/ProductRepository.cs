using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ShoppingContext shoppingContext) : base(shoppingContext)
        {
        }
        public override Product Update(Product entity)
        {
            var product = _shoppingContext.Products.Single(p => p.ProductID == entity.ProductID);
            product.Price = entity.Price;
            product.Name = entity.Name;
            return product;
        }
    }
}
