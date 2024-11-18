using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.Text;

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

        public Sale()
        {
            SaleDate = DateTime.UtcNow;
            
            StringBuilder builder = new StringBuilder();
            builder.Append("ABV_");
            builder.Append(SaleDate.ToString("yyyyMMddHHmmss"));
            builder.Append("_");

            // Just to generate a random.
            // It should be done sequencial.
            var random = new Random();
            int randomNumber = random.Next(0, 100000);
            string formattedRandomNumber = randomNumber.ToString("D5");

            builder.Append(formattedRandomNumber);

            SaleNumber = builder.ToString();

            IsCancelled = false;
        }

        /// <summary>
        /// Performs validation of the sale entity using the SaleValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">SaleNumber format and length</list>
        /// <list type="bullet">CustomerName length</list>
        /// <list type="bullet">TotalAmount value</list>
        /// <list type="bullet">BranchName length</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
