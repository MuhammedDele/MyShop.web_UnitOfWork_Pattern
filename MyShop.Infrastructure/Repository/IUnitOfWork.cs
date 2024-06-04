using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Order> OrderRepository { get;}

        void SaveChanges();
    }
}
