using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for SaleItem entity operations
    /// </summary>
    public interface ISaleItemRepository
    {
        /// <summary>
        /// Creates a new sale item in the repository
        /// </summary>
        /// <param name="saleItem">The sale item to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale item</returns>
        Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a sale item by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale item</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale item if found, null otherwise</returns>
        Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a collection of sale items that belongs to a sale by sale id.
        /// </summary>
        /// <param name="saleId">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <remarks>
        /// The returned collection may be empty if no sale items are found.
        /// Each item in the collection is guaranteed to be non-null.
        /// </remarks>
        /// <returns>A collection of <see cref="SaleItem"/></returns>
        Task<IEnumerable<SaleItem>> GetAllSaleItemsBySaleIdAsync(string saleId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a sale item in the repository
        /// </summary>
        /// <param name="saleItem">The sale item to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale item was updated, false if not found</returns>
        Task<SaleItem?> UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a sale item from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the sale item to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale item was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes all sale items that belongs to a sale from the repository
        /// </summary>
        /// <param name="saleId">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale items was deleted, false if not found</returns>
        Task<bool> DeleteBySaleIdAsync(string saleId, CancellationToken cancellationToken = default);
    }
}
