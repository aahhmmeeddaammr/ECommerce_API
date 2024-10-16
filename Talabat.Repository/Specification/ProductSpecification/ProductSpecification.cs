using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;
using Talabat.core.Specification;

namespace Talabat.Repository.Specification.ProductSpecification
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpacificationParams p) : base(
            P =>
            (!p.brandId.HasValue || P.BrandId == p.brandId) &&
            (!p.categoryId.HasValue || P.CategoryId == p.categoryId) &&
            (string.IsNullOrEmpty( p.search) || P.Name.ToLower().Contains(p.search.ToLower()))
            )
        {
            Incliudes.Add(P => P.Brand);
            Incliudes.Add(P => P.Category);
            if(p.sortingBy is not null)
            {
                if(p.sortingType is not null && p.sortingType == "DESC")
                {
                    switch(p.sortingBy)
                    {
                        case"price":
                            AddOrderByDesc(p => p.Price);
                            break;
                        case "name":
                            AddOrderByDesc(p => p.Name);
                            break;
                        default:
                            break;
                    }
                }
                else{
                    switch (p.sortingBy)
                    {
                        case "price":
                            AddOrderBy(p => p.Price);
                            break;
                        case "name":
                            AddOrderBy(p => p.Name);
                            break;
                        default:
                            break;
                    }
                }
            }
            if(p.index.HasValue && p.size.HasValue)
                AddPagination((p.index.Value-1)*p.size.Value , p.size.Value);
        }
        public ProductSpecification(int id):base(p=>p.Id==id)
        {
            Incliudes.Add(P => P.Brand);
            Incliudes.Add(P => P.Category);
        }

    }
}
