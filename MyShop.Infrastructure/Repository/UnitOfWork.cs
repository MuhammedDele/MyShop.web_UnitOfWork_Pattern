using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingContext _context;
        private IRepository<Customer> customerRepository;
        private IRepository<Product> productRepository;
        private IRepository<Order> orderRepository;

        public UnitOfWork(ShoppingContext context)
        {
            _context = context;
        }
        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(_context);
                }
                return customerRepository;
            }
        }
        public IRepository<Product> ProductRepository
        {
            get
            {
                if(productRepository == null)
                {
                    productRepository = new ProductRepository(_context);    
                }
                return productRepository;
            }
        }
        public IRepository<Order> OrderRepository
        {
            get
            {
                if(orderRepository == null)
                {
                    orderRepository = new OrderRepository(_context);
                }
                return orderRepository;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
