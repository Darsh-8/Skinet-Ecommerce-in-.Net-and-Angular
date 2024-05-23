using System;

namespace Core.Entities
{
    /// <summary>
    /// Represents a brand of a product in the application.
    /// </summary>
    public class ProductBrand : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the brand.
        /// </summary>
        public string Name { get; set; }
    }
}
