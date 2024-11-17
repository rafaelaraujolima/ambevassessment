using Ambev.DeveloperEvaluation.Domain.Entities.Product;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .Length(3, Constants.Constants.ProductNameMaxLength)
                    .WithMessage("Name must be at least 3 characters long and cannot be longer than "
                                + Constants.Constants.ProductNameMaxLength.ToString()
                                + " characters.");

            RuleFor(product => product.Price)
                .GreaterThan(0m)
                .WithMessage("Price must be greater than 0.0.");

            RuleFor(product => product.Description)
                .NotEmpty()
                .Length(3, 200)
                    .WithMessage("Description must be at least 3 characters long and not greater than 200.");

            RuleFor(product => product.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock must be greater than or equals to 0.");
        }
    }
}
