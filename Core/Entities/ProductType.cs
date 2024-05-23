using System;

namespace Core.Entities
{
    /// <summary>
    /// Represents a type of product in the application.
    /// </summary>
    public class ProductType : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the product type.
        /// </summary>
        public string Name { get; set; }
    }
}
