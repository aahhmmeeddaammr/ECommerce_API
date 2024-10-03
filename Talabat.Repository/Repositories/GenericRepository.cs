using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;
using Talabat.core.Interfaces;
using Talabat.core.Specification;
using Talabat.Repository.Data;
using Talabat.Repository.Specification;

namespace Talabat.Repository.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext _dbcontext;

        public GenericRepository(StoreDbContext context)
        {
            _dbcontext = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync(ISpecification<T> specification)
        {   
            return await SpecofocationEvaluator<T>.GetQuery(_dbcontext.Set<T>() , specification).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, ISpecification<T> specification)
        {
            return await SpecofocationEvaluator<T>.GetQuery(_dbcontext.Set<T>() , specification).FirstOrDefaultAsync();
        }
    }
}
