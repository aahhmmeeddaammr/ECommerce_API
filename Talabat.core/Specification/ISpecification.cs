using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;

namespace Talabat.core.Specification
{
    public interface ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T,bool>>Critria{ get; set; }
        public List<Expression<Func<T,object>>>Incliudes{ get; set; }

        public Expression<Func<T,object>>? orderBy { get; set; }
        public Expression<Func<T, object>>? orderByDesc { get; set; }
        public string? orderType { get; set; }
        public int Count { get; set; }

        public int skip { get; set; }
        public int take { get; set; }
        public bool Pagination { get; set; }
    }
}
