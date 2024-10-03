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
        public ProductSpecification():base() {
            Incliudes.Add(P => P.Brand);
            Incliudes.Add(P => P.Category);
        }
        public ProductSpecification(Expression<Func<Product , bool>> expression):base(expression)
        {
            Incliudes.Add(P => P.Brand);
            Incliudes.Add(P => P.Category);
        }

    }
}
