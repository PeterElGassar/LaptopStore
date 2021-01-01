using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrands : BaseSpecification<Product>
    { 
        public ProductsWithTypesAndBrands()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);

        }
        public ProductsWithTypesAndBrands(int id) : base(p => p.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}