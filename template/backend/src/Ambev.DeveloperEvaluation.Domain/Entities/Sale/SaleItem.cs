using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sale
{
    /// <summary>
    /// Represents a sale item in the system with information about the sale item that belongs to a sale.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets the unique identifier of the sale item.
        /// </summary>
        /// <returns>The saleitem's ID as <see cref="string"/>.</returns>
        public string SaleItemId => Id.ToString();

        /// <summary>
        /// Gets the sale id that this sale item belongs.
        /// Must not be null or empty or white space.
        /// </summary>
        /// <returns>The sale id.</returns>
        public string SaleId { get; set; }

        /// <summary>
        /// Gets the product id that this sale item represents.
        /// Must not be null or empty or white space.
        /// </summary>
        /// <returns>The product id.</returns>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets the product name that this sale item represents.
        /// Must not be null or empty or white space.
        /// </summary>
        /// <returns>The product name.</returns>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets the price of one unit of the product that this sale item represents.
        /// Must be greater than 0.0.
        /// </summary>
        /// <returns>The unit price.</returns>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets the quantity that this sale item has for the product.
        /// </summary>
        /// <returns>The quantity.</returns>
        /// <remarks>
        /// <listheader>Rules:</listheader>
        /// <list type="bullet">Must be greather than 0.</list>
        /// <list type="bullet">The maximum limit for the same item per sale is 20</list>
        /// </remarks>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets the discount that this sale item has.
        /// </summary>
        /// <returns>The discount.</returns>
        /// <remarks>
        /// <listheader>Rules</listheader>
        /// <list type="bullet">4+ items: 10% discount</list>
        /// <list type="bullet">10-20 items: 20% discount</list>
        /// <list type="bullet">3- items: no discount allowed</list>
        /// </remarks>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets the total amount calculated of the sale item.
        /// It's calculated by <see cref="UnitPrice"/> * <see cref="Quantity"/> * <see cref="Discount"/>
        /// </summary>
        /// <returns>The total amount.</returns>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets the status of the sale item.
        /// Indicates whether the item is cancelled on the sale or not.
        /// </summary>
        /// <returns>The status.</returns>
        /// <remarks>
        /// <listheader>Returns</listheader>
        /// <list type="bullet"><see langword="true"></see> : the item is cancelled</list>
        /// <list type="bullet"><see langword="false"></see> : the item is not cancelled</list>
        /// </remarks>
        public bool IsCancelled { get; set; }
    }
}
