using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repository;
using MyShop.Web.Models;

namespace MyShop.Web.Controllers
{
    public class OrderController : Controller
    {
        //private readonly ShoppingContext _context;
        private readonly IUnitOfWork _unitOfWork;
        
        //private readonly IRepository<Product> _productRepository;
        //private readonly IRepository<Order> _orderRepository;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //productRepository = productRepository;
             //_orderRepository= orderRepository;
            //_context = context;
        }

        public IActionResult Index()
        {
            var orders = _unitOfWork.OrderRepository.All();

            return View(orders);
        }


        public IActionResult Create()
        {
            
            var products = _unitOfWork.ProductRepository.All();
            
            return View(products);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");
            var customer = _unitOfWork.CustomerRepository.Find(c => c.Name == model.Customer.Name).FirstOrDefault();

            if(customer != null)
            {
                customer = new Customer
                {
                    Name = model.Customer.Name,
                    ShippingAddress = model.Customer.ShippingAddress,
                    City = model.Customer.City,
                    PostalCode = model.Customer.PostalCode,
                    Country = model.Customer.Country
                };
                _unitOfWork.CustomerRepository.Update(customer);
            }
            else
            {
                customer = new Customer
                {
                    Name = model.Customer.Name,
                    ShippingAddress = model.Customer.ShippingAddress,
                    City = model.Customer.City,
                    PostalCode = model.Customer.PostalCode,
                    Country = model.Customer.Country
                };
            }

            var order = new Order
            {
                Orderlines = model.LineItems
                    .Select(line => new Orderline { ProductID = line.ProductID, Quantity = line.Quantity })
                    .ToList(),
                OrderDate = DateTime.Now,
                Customer = customer
            };

            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.OrderRepository.SaveChanges();

            return Ok("Order Created");
        }

    }
}
