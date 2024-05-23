using Core.Entities;

namespace Core.Specifications
{
    // A specification class for fetching products with their types and brands
    public class ProductswithTypesandBrandsSpecification : BaseSpecification<Product>
    {
        // Constructor to specify sorting criteria
        public ProductswithTypesandBrandsSpecification(string sort, int? brandId, int? typeId) : base(x => (!brandId.HasValue || x.ProductBrandId == brandId) && (!typeId.HasValue || x.ProductTypeId == typeId))
        {
            // Include related entities (ProductType and ProductBrand)
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

            // Default sorting order by name
            AddOrderBy(x => x.Name);

            // Check if a specific sorting option is provided
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
