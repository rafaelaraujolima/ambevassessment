using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sale
{
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Gets the unique identifier of the sale.
        /// </summary>
        /// <returns>The sale's ID as <see cref="string"/>.</returns>
        public string SaleId => Id.ToString();

        /// <summary>
        /// Gets the number of the sale.
        /// Must be a valid sale number following the pattern ABV_yyyyMMddHHmmss_SUFFIX:D5.
        /// </summary>
        /// <returns>The sale number.</returns>
        public string SaleNumber { get; set; }

        /// <summary>
        /// Gets the date of the sale.
        /// </summary>
        /// <returns>The sale date.</returns>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets the customer id that created the sale.
        /// </summary>
        /// <returns>The customer id.</returns>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets the customer name that created the sale.
        /// </summary>
        /// <returns>The customer name.</returns>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets the total amount of the sale.
        /// It's calculated by the sum of all <see cref="SaleItem"/> that is on the sale.
        /// </summary>
        /// <returns>The total amount.</returns>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets the branch id where the sale was made.
        /// </summary>
        /// <returns>The branch id.</returns>
        public int BranchId { get; set; }

        /// <summary>
        /// Gets the branch name where the sale was made.
        /// </summary>
        /// <returns>The branch name.</returns>
        public string BranchName { get; set; }

        /// <summary>
        /// Gets the status of the sale.
        /// Indicates whether the sale is cancelled or not.
        /// </summary>
        /// <returns>The status.</returns>
        /// <remarks>
        /// <listheader>Returns</listheader>
        /// <list type="bullet"><see langword="true"></see> : the sale is cancelled</list>
        /// <list type="bullet"><see langword="false"></see> : the sale is not cancelled</list>
        /// </remarks>
        public bool IsCancelled { get; set; }
        public ICollection<SaleItem> Items { get; set; } = new List<SaleItem>();
    }
}
