using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Command for updating a sale.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for updating a sale, 
    /// including sale number, sale date, customer id, customer name, total amount, branch id, branch name and the status. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="UpdateSaleResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateSaleCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateSaleCommand : IRequest<UpdateSaleResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the sale in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the total amount of the sale.
        /// It's calculated by the sum of all <see cref="SaleItem"/> that is on the sale.
        /// </summary>
        public decimal TotalAmount { get; set; }

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

        /// <summary>
        /// Initializes a new instance of UpdateSaleCommand
        /// </summary>
        /// <param name="id">The ID of the sale to update</param>
        public UpdateSaleCommand(Guid id)
        {
            Id = id;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new UpdateSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
