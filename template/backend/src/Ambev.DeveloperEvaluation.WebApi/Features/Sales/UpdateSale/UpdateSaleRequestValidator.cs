using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleRequest that defines validation rules for sale update.
    /// </summary>
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// <listheader>Validation rules include:</listheader>
        /// <list type="bullet">TotalAmount: Required, must be greater or equal to 0.0</list>
        /// </remarks>
        public UpdateSaleRequestValidator()
        {
            RuleFor(sale => sale.TotalAmount)
                .GreaterThanOrEqualTo(0m)
                .WithMessage("Total amount must be greater than or equal to 0.0.");
        }
    }
}
