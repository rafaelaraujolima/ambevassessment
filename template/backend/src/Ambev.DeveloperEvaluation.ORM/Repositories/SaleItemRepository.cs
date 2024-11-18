using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleItemRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleItemRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new sale item in the repository
        /// </summary>
        /// <param name="saleItem">The sale item to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale item</returns>
        public async Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            await _context.SaleItems.AddAsync(saleItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return saleItem;
        }

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
        public async Task<IEnumerable<SaleItem>> GetAllSaleItemsBySaleIdAsync(string saleId, CancellationToken cancellationToken = default)
        {
            return await _context.SaleItems.Where(si => si.SaleId.Equals(saleId)).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a sale item by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale item</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale item if found, null otherwise</returns>
        public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.SaleItems.FirstOrDefaultAsync(si => si.Id == id, cancellationToken);
        }

        /// <summary>
        /// Update a sale item in the repository
        /// </summary>
        /// <param name="saleItem">The sale item to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale item was updated, false if not found</returns>
        public async Task<SaleItem?> UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            var saleItemToUpdate = await GetByIdAsync(saleItem.Id, cancellationToken);
            if (saleItemToUpdate == null)
            {
                return null;
            }

            saleItemToUpdate.ProductName = saleItem.ProductName;
            saleItemToUpdate.Quantity = saleItem.Quantity;
            saleItemToUpdate.Discount = saleItem.Discount;
            saleItemToUpdate.TotalAmount = saleItem.TotalAmount;
            saleItemToUpdate.IsCancelled = saleItem.IsCancelled;

            _context.SaleItems.Update(saleItemToUpdate);
            await _context.SaveChangesAsync(cancellationToken);
            return saleItemToUpdate;
        }

        /// <summary>
        /// Deletes a sale item from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the sale item to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale item was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var saleItem = await GetByIdAsync(id, cancellationToken);
            if (saleItem == null)
                return false;

            _context.SaleItems.Remove(saleItem);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Deletes all sale items that belongs to a sale from the repository
        /// </summary>
        /// <param name="saleId">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale items was deleted, false if not found</returns>
        public async Task<bool> DeleteBySaleIdAsync(string saleId, CancellationToken cancellationToken = default)
        {
            var saleItems = await GetAllSaleItemsBySaleIdAsync(saleId, cancellationToken);
            if (!saleItems.Any())
                return false;

            _context.SaleItems.RemoveRange(saleItems);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
