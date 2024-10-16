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
        private readonly IGenericRepository<ProductCategory> _categoryrepository;
        private readonly IGenericRepository<ProductBrand> _brandsRepository;

        public ProductController(
            IGenericRepository<Product> repository ,
            IMapper mapper,
            IGenericRepository<ProductCategory> categoryrepository,
            IGenericRepository<ProductBrand> BrandsRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryrepository = categoryrepository;
            _brandsRepository = BrandsRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _repository.GetByIdAsync(id , new ProductSpecification(id));
            if (product == null)
            {
                return NotFound(new {message="Not Found Product" , StatusCode=404});
            }
            var MappedProducts = _mapper.Map<Product, ProductDTO>(product);
            return Ok(MappedProducts);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetAllProducts([FromQuery]ProductSpacificationParams param0s)
        {
            var spec = new ProductSpecification(param0s);
            var products = await _repository.GetAllAsync(spec);
            var MappedProducts = _mapper.Map<IEnumerable< Product >,IEnumerable< ProductDTO>>(products);
            int count = spec.Count;
            return Ok(new { count,data = MappedProducts , page=param0s.index , PageSize = param0s.size  });
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetAllProductsCategories()
        {
            var Categories =await _categoryrepository.GetAllAsync();
            return Ok(Categories);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllProductsBrands()
        {
            var Brands = await _brandsRepository.GetAllAsync();
            return Ok(Brands);
        }
        
    }
}
