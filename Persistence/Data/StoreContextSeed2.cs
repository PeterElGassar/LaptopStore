using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence.Data
{
    public class StoreContextSeed2
    {
         public static async Task SeedAsync(StoreContext context, ILoggerFactory logger)
        {
            try
            {
                //Brands
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Persistence/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var brand in brands)
                    {
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }
                 //Types
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Persistence/Data/SeedData/types.json");

                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var type in productTypes)
                    {
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }




                //Products
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Persistence/Data/SeedData/products.json");

                    var brands = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var product in brands)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }

               

            }
            catch(Exception ex)
            {
                var loggerMs =logger.CreateLogger<StoreContextSeed2>();
                loggerMs.LogError(ex.Message);
                
            }


        }
    }
}