using AutoMapper;
using Talabat.API.DTOs;
using Talabat.core.Entities;

namespace Talabat.API.Helpers
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product ,ProductDTO> ()
                .ForMember(p=>p.BrandName , o=>o.MapFrom(r=>r.Brand.Name))
                .ForMember(p => p.BrandName, o => o.MapFrom(r => r.Category.Name))
                .ForMember(p=>p.PictureUrl , o=>o.MapFrom<ProductImageURLResolver>())
                .ReverseMap();
        }
    }
}
