using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.core.Entities;

namespace Talabat.Repository.Data
{
    public class StoreContextSeed
    {
 
        public async static Task SeedAsync(StoreDbContext _dbcontext)
        {
            var brandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            if (brands is not null && brands.Count > 0 && _dbcontext.ProductBrands.Count() == 0)
            {
                foreach (var brand in brands)
                {
                    _dbcontext.Set<ProductBrand>().Add(brand);
                }
                await _dbcontext.SaveChangesAsync();
            }

            var categoriesData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/categories.json");
            var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
            if (categories is not null && categories.Count > 0 && _dbcontext.ProductCategories.Count() == 0)
            {
                foreach (var category in categories)
                {
                    _dbcontext.Set<ProductCategory>().Add(category);
                }
                await _dbcontext.SaveChangesAsync();
            }

            var productsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            if (products is not null && products.Count > 0 && _dbcontext.products.Count() == 0)
            {
                foreach (var product in products)
                {
                    _dbcontext.Set<Product>().Add(product);
                }
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
