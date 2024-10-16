using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;
using Talabat.core.Specification;

namespace Talabat.Repository.Specification
{
    internal static class SpecofocationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query,ISpecification<T> specification )
        {
            var Query = query;
            if(specification.Critria != null)
            {
                Query = Query.Where(specification.Critria);
            }
            specification.Count = Query.Count();
            if(specification.orderBy != null)
            {
                Query = Query.OrderBy(specification.orderBy);
            }else if(specification.orderByDesc != null)
            {
                Query = Query.OrderByDescending(specification.orderByDesc);
            }
            if (specification.Pagination)
            {
                Query = Query.Skip(specification.skip).Take(specification.take);
            }
            Query = specification.Incliudes.Aggregate(Query , (q , include)=>q.Include(include));
            return Query;
        }
    }
}
