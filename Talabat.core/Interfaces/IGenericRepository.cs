using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;
using Talabat.core.Specification;

namespace Talabat.core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public  Task<IEnumerable<T>> GetAllAsync(ISpecification<T> specification);

        public  Task<T?> GetByIdAsync(int id , ISpecification<T> specification);

    }
}
