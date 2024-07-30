using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrustructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context){
            if(!context.ProductBrands.Any()){
                var jsonData = File.ReadAllText("../Infrustructure/Data/SeedData/brands.json");
                var entities = JsonSerializer.Deserialize<List<ProductBrand>>(jsonData);
                context.ProductBrands.AddRange(entities);
            }
            if(!context.ProductTypes.Any()){
                var jsonData = File.ReadAllText("../Infrustructure/Data/SeedData/types.json");
                var entities = JsonSerializer.Deserialize<List<ProductType>>(jsonData);
                context.ProductTypes.AddRange(entities);
            }
            if(!context.Products.Any()){
                var jsonData = File.ReadAllText("../Infrustructure/Data/SeedData/products.json");
                var entities = JsonSerializer.Deserialize<List<Product>>(jsonData);
                context.Products.AddRange(entities);
            }

            if(context.ChangeTracker.HasChanges()) 
                await context.SaveChangesAsync();
        }
    }
}