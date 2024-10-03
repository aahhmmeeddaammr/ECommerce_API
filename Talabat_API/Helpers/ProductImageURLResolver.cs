using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Internal;
using System.Linq.Expressions;
using System.Reflection;
using Talabat.API.DTOs;
using Talabat.core.Entities;

namespace Talabat.API.Helpers
{
    public class ProductImageURLResolver : IValueResolver<Product, ProductDTO, string?>
    {
        private readonly IConfiguration configuration;

        public ProductImageURLResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string? Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (source.PictureUrl != null || source.PictureUrl != "") 
                 return $"{configuration["API_Base_URL"]}/{source.PictureUrl}";
            return null;
        }
    }
}
