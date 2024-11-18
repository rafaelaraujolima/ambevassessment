using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleCommand that defines validation rules for sale creation command.
    /// </summary>
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// <listheader>Validation rules include:</listheader>
        /// <list type="bullet">CustomerName: Required, must not be empty</list>
        /// <list type="bullet">TotalAmount: Required, must be greater than or equal to 0.0</list>
        /// <list type="bullet">BranchName: Required, must not be empty</list>
        /// </remarks>
        public CreateSaleCommandValidator()
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
