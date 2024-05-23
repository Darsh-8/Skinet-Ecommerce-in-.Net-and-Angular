using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface for the product repository.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves a product by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the product to retrieve.</param>
        /// <returns>The product with the specified identifier, or null if not found.</returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Retrieves all products asynchronously.
        /// </summary>
        /// <returns>A list of all products.</returns>
        Task<IReadOnlyList<Product>> GetProductsAsync();

        /// <summary>
        /// Retrieves all product brands asynchronously.
        /// </summary>
        /// <returns>A list of all product brands.</returns>
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        /// <summary>
        /// Retrieves all product types asynchronously.
        /// </summary>
        /// <returns>A list of all product types.</returns>
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
