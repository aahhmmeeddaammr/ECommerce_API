using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;
using Talabat.core.Interfaces;
using Talabat.Repository.Data;

namespace Talabat.Repository.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext _dbcontext;

        public GenericRepository(StoreDbContext context)
        {
            _dbcontext = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IEnumerable<T>)await _dbcontext.products.Include(P => P.Category).Include(P => P.Brand).AsNoTracking().ToListAsync();
            }
            return await _dbcontext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            if (typeof(T) == typeof(Product))
            {
                return await _dbcontext.products.Where(P => P.Id == id).Include(P => P.Category).Include(P => P.Brand).FirstOrDefaultAsync() as T;
            }
            return await _dbcontext.Set<T>().FindAsync(id);
        }
    }
}
