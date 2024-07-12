using Core.Entities;
using Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for a generic repository pattern.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets an entity by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the entity to retrieve.</param>
        /// <returns>The entity with the specified identifier, or null if not found.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Gets all entities of type T asynchronously.
        /// </summary>
        /// <returns>A list of all entities of type T.</returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Gets an entity with the specified specifications asynchronously.
        /// </summary>
        /// <param name="spec">The specification to apply.</param>
        /// <returns>The entity matching the specifications, or null if not found.</returns>
        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        /// <summary>
        /// Gets a list of entities matching the specified specifications asynchronously.
        /// </summary>
        /// <param name="spec">The specification to apply.</param>
        /// <returns>A list of entities matching the specifications.</returns>
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}
