using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem
{
    /// <summary>
    /// Validator for DeleteSaleItemCommand
    /// </summary>
    public class DeleteSaleItemValidator : AbstractValidator<DeleteSaleItemCommand>
    {
        /// <summary>
        /// Initializes validation rules for DeleteSaleItemCommand
        /// </summary>
        public DeleteSaleItemValidator() 
        {
            RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("SaleItem ID is required");
        }
    }
}
