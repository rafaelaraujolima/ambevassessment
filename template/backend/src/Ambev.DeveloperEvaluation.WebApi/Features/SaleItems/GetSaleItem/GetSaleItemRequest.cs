namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem
{
    /// <summary>
    /// Request model for getting a sale item by ID
    /// </summary>
    public class GetSaleItemRequest
    {
        /// <summary>
        /// The unique identifier of the sale item to retrieve
        /// </summary>
        public Guid Id { get; set; }
    }
}
