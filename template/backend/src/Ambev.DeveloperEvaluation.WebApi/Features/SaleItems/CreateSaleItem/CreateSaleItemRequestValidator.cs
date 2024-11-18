using Ambev.DeveloperEvaluation.Domain.Constants;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem
{
    /// <summary>
    /// Validator for CreateSaleItemRequest that defines validation rules for sale item creation.
    /// </summary>
    public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleItemRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// <listheader>Validation rules include:</listheader>
        /// <list type="bullet">SaleId: Required, must not be empty</list>
        /// <list type="bullet">ProductName: Required, must not be empty</list>
        /// <list type="bullet">UnitPrice: Required, must be greater than 0.0.</list>
        /// <list type="bullet">Quantity: Required, must be greater than 0 and less than or equals to <see cref="Constants.MaxQuantityPerItem"/>.</list>
        /// <list type="bullet">Discount: Required, must be from 0.0 to 1.0./>.</list>
        /// <list type="bullet">TotalAmount: Required, must be greater than or equals to 0.0./>.</list>
        /// </remarks>
        public CreateSaleItemRequestValidator()
        {
            RuleFor(saleItem => saleItem.SaleId)
                .NotEmpty()
                .WithMessage("Sale id must not be empty.");

            RuleFor(saleItem => saleItem.ProductName)
                .NotEmpty()
                .WithMessage("Product name must not be empty.");

            RuleFor(saleItem => saleItem.UnitPrice)
                .GreaterThanOrEqualTo(0m)
                .WithMessage("Unit price must be greater than 0.0.");

            RuleFor(saleItem => saleItem.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.")
                .LessThanOrEqualTo(Constants.MaxQuantityPerItem)
                .WithMessage("Quantity must be less than or equals to "
                            + Constants.MaxQuantityPerItem);

            RuleFor(saleItem => saleItem.Discount)
                .InclusiveBetween(0m, 1m)
                .WithMessage("Discount must be from 0.0 to 1.0.")
                .Must((saleItem, discount) => IsValidDiscount(saleItem.Quantity, discount))
                .WithMessage("Discount must be 10% for 4-9 items, 20% for 10-20 items.");

            RuleFor(saleItem => saleItem.TotalAmount)
                .GreaterThanOrEqualTo(0m)
                .WithMessage("Total amount must be greater than or equals to 0.0.");
        }

        private static bool IsValidDiscount(int quantity, decimal discount)
        {
            if (quantity >= 4 && quantity <= 9)
            {
                return discount == 0.10m;
            }
            else if (quantity >= 10 && quantity <= 20)
            {
                return discount == 0.20m;
            }

            return true;
        }
    }
}
