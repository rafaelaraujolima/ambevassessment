using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem
{
    /// <summary>
    /// Validator for DeleteSaleItemRequest
    /// </summary>
    public class DeleteSaleItemRequestValidator : AbstractValidator<DeleteSaleItemRequest>
    {
        /// <summary>
        /// Initializes validation rules for DeleteSaleItemRequest
        /// </summary>
        public DeleteSaleItemRequestValidator()
        {
            RuleFor(si => si.Id)
            .NotEmpty()
            .WithMessage("Sale item ID is required");

        }
    }
}
