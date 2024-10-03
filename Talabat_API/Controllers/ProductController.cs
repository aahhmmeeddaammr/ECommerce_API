using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTOs;
using Talabat.core.Entities;
using Talabat.core.Interfaces;
using Talabat.core.Specification;
using Talabat.Repository.Specification.ProductSpecification;

namespace Talabat.API.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> repository ,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _repository.GetByIdAsync(id , new ProductSpecification());
            if (product == null)
            {
                return NotFound();
            }
            var MappedProducts = _mapper.Map<Product, ProductDTO>(product);
            return Ok(MappedProducts);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await _repository.GetAllAsync(new ProductSpecification());
            var MappedProducts = _mapper.Map<IEnumerable< Product >,IEnumerable< ProductDTO>>(products);
            return Ok(MappedProducts);
        }
    }
}
