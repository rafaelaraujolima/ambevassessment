using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleRequest that defines validation rules for sale creation.
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// <listheader>Validation rules include:</listheader>
        /// <list type="bullet">CustomerName: Required, must not be empty</list>
        /// <list type="bullet">TotalAmount: Required, must be greater than or equal to 0.0</list>
        /// <list type="bullet">BranchName: Required, must not be empty</list>
        /// </remarks>
        public CreateSaleRequestValidator()
        {
            RuleFor(sale => sale.CustomerName)
                .NotEmpty()
                .WithMessage("Customer name must not be empty.");

            RuleFor(sale => sale.TotalAmount)
                .GreaterThanOrEqualTo(0m)
                .WithMessage("Total amount must be greater than or equal to 0.0.");

            RuleFor(sale => sale.BranchName)
                .NotEmpty()
                .WithMessage("Branch name must not be empty.");
        }
    }
}
