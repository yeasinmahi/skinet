using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypeAndBrandSpecification : BaseSpecifications<Product>
    {
        public ProductWithTypeAndBrandSpecification()
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }

        public ProductWithTypeAndBrandSpecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
    }
}