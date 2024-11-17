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
                .MinimumLength(3)
                    .WithMessage("Name must be at least 3 characters long.")
                .MaximumLength(Constants.Constants.ProductNameMaxLength)
                    .WithMessage("Name cannot be longer than "
                                + Constants.Constants.ProductNameMaxLength.ToString()
                                + " characters.");

            RuleFor(product => product.Price)
                .GreaterThan(0m)
                .WithMessage("Price must be greater than 0.0.");

            RuleFor(product => product.Description)
                .NotEmpty()
                .MinimumLength(3)
                    .WithMessage("Description must be at least 3 characters long.")
                .MaximumLength(200)
                    .WithMessage("Name cannot be longer than "
                                + 200
                                + " characters.");
        }
    }
}
