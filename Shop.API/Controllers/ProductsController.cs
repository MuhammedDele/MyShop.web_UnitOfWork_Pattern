using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Infrastructure.Repository;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return unitOfWork.ProductRepository.All();
        }
        [HttpGet("id")]
        public IActionResult GetProduct(int id)
        {
            var product = unitOfWork.ProductRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            unitOfWork.ProductRepository.Add(product);
            unitOfWork.SaveChanges();
            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }
        [HttpPut]
        public IActionResult PutProduct(int id,Product product)
        {
            if(id != product.ProductID)
            {
                return BadRequest();
            }
            try
            {
                unitOfWork.ProductRepository.Update(product);
                unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }
        private bool ProductExists(int id)
        {
            return unitOfWork.ProductRepository.Get(id) != null;
        }

    }
}
