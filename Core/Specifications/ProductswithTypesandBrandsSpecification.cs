using Core.Entities;

namespace Core.Specifications
{
    // A specification class for fetching products with their types and brands
    public class ProductswithTypesandBrandsSpecification : BaseSpecification<Product>
    {
        // Constructor to specify sorting criteria
        public ProductswithTypesandBrandsSpecification(ProductsSpecParam productsParams)
            : base(x =>
                (string.IsNullOrEmpty(productsParams.Search) || x.Name.ToLower().Contains(productsParams.Search)) &&
                (!productsParams.BrandId.HasValue || x.ProductBrandId == productsParams.BrandId) &&
                (!productsParams.TypeId.HasValue || x.ProductTypeId == productsParams.TypeId))
        {
            // Include related entities (ProductType and ProductBrand)
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

            // Default sorting order by name
            AddOrderBy(x => x.Name);

            ApplyPaging(productsParams.PageSize * (productsParams.PageIndex - 1), productsParams.PageSize);

            // Check if a specific sorting option is provided
            if (!string.IsNullOrEmpty(productsParams.Sort))
            {
                switch (productsParams.Sort)
                {
                    // Sort by price ascending
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    // Sort by price descending
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    // Sort by name (default)
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        // Constructor to fetch a product by its ID
        public ProductswithTypesandBrandsSpecification(int id) : base(x => x.Id == id)
        {
            // Include related entities (ProductType and ProductBrand)
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
