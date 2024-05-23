using Core.Entities; // Assuming this is where the Product entity is defined

namespace API.Dtos
{
    // Data Transfer Object (DTO) for returning product information
    public class ProductToReturnDto
    {
        // Unique identifier of the product
        public int Id { get; set; }

        // Name of the product
        public string Name { get; set; }

        // Description of the product
        public string Description { get; set; }

        // Price of the product
        public decimal Price { get; set; }

        // URL to the picture of the product
        public string PictureUrl { get; set; }

        // Type of the product (e.g., electronics, clothing)
        public string ProductType { get; set; }

        // Brand of the product
        public string ProductBrand { get; set; }
    }
}
