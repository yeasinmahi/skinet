using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure.Data
{
    public class ProductRepository : IProductRepository
    {

        public StoreContext Context { get; }

        public ProductRepository(StoreContext context)
        {
            Context = context;
        }

        public async Task<List<ProductBrand>> GetProductBrandsAsync()
        {
            return await Context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await Context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await Context.Products.ToListAsync();
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await Context.ProductTypes.ToListAsync();
        }
    }
}