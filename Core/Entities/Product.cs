using System;

namespace Core.Entities
{
    /// <summary>
    /// Represents a product in the application.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the URL of the product's picture.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product's type.
        /// </summary>
        public int ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the brand of the product.
        /// </summary>
        public ProductBrand ProductBrand { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product's brand.
        /// </summary>
        public int ProductBrandId { get; set; }
    }
}
