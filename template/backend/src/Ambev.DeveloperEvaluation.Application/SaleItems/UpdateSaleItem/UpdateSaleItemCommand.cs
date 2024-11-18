using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem
{
    /// <summary>
    /// Command for updating a sale item.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for updating a sale item, 
    /// including sale id, product id, product name, unit price, quantity, discount, total amount and the status. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="UpdateSaleItemResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateSaleItemCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateSaleItemCommand : IRequest<UpdateSaleItemResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale item.
        /// </summary>
        /// <value>A GUID that uniquely identifies the sale item in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the sale id that this sale item belongs.
        /// Must not be null or empty or white space.
        /// </summary>
        public string SaleId { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product id that this sale item represents.
        /// Must not be null or empty or white space.
        /// </summary>
        public string ProductId { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product name that this sale item represents.
        /// Must not be null or empty or white space.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets the price of one unit of the product that this sale item represents.
        /// Must be greater than 0.0.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets the quantity that this sale item has for the product.
        /// </summary>
        /// <remarks>
        /// <listheader>Rules:</listheader>
        /// <list type="bullet">Must be greather than 0.</list>
        /// <list type="bullet">The maximum limit for the same item per sale is 20</list>
        /// </remarks>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets the discount that this sale item has.
        /// </summary>
        /// <remarks>
        /// <listheader>Rules:</listheader>
        /// <list type="bullet">4+ items: 10% discount</list>
        /// <list type="bullet">10-20 items: 20% discount</list>
        /// <list type="bullet">3- items: no discount allowed</list>
        /// </remarks>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets the total amount calculated of the sale item.
        /// It's calculated by <see cref="UnitPrice"/> * <see cref="Quantity"/> * <see cref="Discount"/>
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets the status of the sale item.
        /// Indicates whether the item is cancelled on the sale or not.
        /// </summary>
        /// <remarks>
        /// <listheader>Returns</listheader>
        /// <list type="bullet"><see langword="true"></see> : the item is cancelled</list>
        /// <list type="bullet"><see langword="false"></see> : the item is not cancelled</list>
        /// </remarks>
        public bool IsCancelled { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of UpdateSaleItemCommand
        /// </summary>
        /// <param name="id">The ID of the sale item to update</param>
        public UpdateSaleItemCommand(Guid id)
        {
            Id = id;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new UpdateSaleItemCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
