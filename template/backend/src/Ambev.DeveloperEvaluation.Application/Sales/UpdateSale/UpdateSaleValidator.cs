using Ambev.DeveloperEvaluation.Domain.Constants;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleCommand that defines validation rules for sale update command.
    /// </summary>
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// <listheader>Validation rules include:</listheader>
        /// <list type="bullet">TotalAmount: Required, must be greater or equal to 0.0</list>
        /// </remarks>
        public UpdateSaleCommandValidator()
        {
            RuleFor(sale => sale.TotalAmount)
                .GreaterThanOrEqualTo(0m)
                .WithMessage("Total amount must be greater than or equal to 0.0.");
        }
    }
}
