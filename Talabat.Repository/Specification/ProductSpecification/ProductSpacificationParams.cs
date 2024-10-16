using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Repository.Specification.ProductSpecification
{
    public class ProductSpacificationParams
    {
        public string? sortingBy{ get; set; }
        public string? sortingType { get; set;}
        public int? brandId { get; set;}
        public int? categoryId { get; set;}
        public string? search { get; set;}

        public int? index { get; set;}
        public int? size { get; set;}
    }
}
