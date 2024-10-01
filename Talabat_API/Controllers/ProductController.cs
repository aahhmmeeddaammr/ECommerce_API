using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.core.Entities;
using Talabat.core.Interfaces;

namespace Talabat.API.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductController(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }
    }
}
