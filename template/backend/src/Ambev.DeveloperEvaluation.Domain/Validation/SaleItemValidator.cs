using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
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
                .LessThanOrEqualTo(Constants.Constants.MaxQuantityPerItem)
                .WithMessage("Quantity must be less than or equals to "
                            + Constants.Constants.MaxQuantityPerItem);

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
