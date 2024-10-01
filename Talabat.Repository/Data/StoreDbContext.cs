using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entities;

namespace Talabat.Repository.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());    
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> ProductBrands {  get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
