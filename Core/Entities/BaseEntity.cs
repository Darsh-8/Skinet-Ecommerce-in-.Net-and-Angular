using System;

namespace Core.Entities
{
    /// <summary>
    /// Represents the base entity with an integer identifier.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public int Id { get; set; }
    }
}
