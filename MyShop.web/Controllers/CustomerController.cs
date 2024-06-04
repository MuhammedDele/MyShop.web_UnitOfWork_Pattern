using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repository;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly ShoppingContext _context;
        private readonly IRepository<Customer> _repository;


        public CustomerController(ShoppingContext context, IRepository<Customer> customerRepository)
        {
            //_context = context;
            _repository = customerRepository;
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                var customers = _repository.All();
                return View(customers);
            }
            else
            {
                var customers = new[] { _repository.Get(id.Value) };
                return View(customers);
            }
        }
    }
}
