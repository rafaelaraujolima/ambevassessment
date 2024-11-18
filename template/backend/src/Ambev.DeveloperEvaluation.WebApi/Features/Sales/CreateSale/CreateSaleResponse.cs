namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// API response model for CreateSale operation
    /// </summary>
    public class CreateSaleResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created sale in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the number of the sale.
        /// Must be a valid sale number following the pattern ABV_yyyyMMddHHmmss_D5.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets the date and time of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets the customer id that created the sale.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets the customer name that created the sale.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets the total amount of the sale.
        /// It's calculated by the sum of all <see cref="SaleItem"/> that is on the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets the branch id where the sale was made.
        /// </summary>
        public int BranchId { get; set; }

        /// <summary>
        /// Gets the branch name where the sale was made.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Gets the status of the sale.
        /// Indicates whether the sale is cancelled or not.
        /// </summary>
        /// <remarks>
        /// <listheader>Returns</listheader>
        /// <list type="bullet"><see langword="true"></see> : the sale is cancelled</list>
        /// <list type="bullet"><see langword="false"></see> : the sale is not cancelled</list>
        /// </remarks>
        public bool IsCancelled { get; set; }
    }
}
