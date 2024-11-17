using Ambev.DeveloperEvaluation.Domain.Constants;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    /// <summary>
    /// Validator for UpdateProductCommand that defines validation rules for product update command.
    /// </summary>
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateProductCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// <listheader>Validation rules include:</listheader>
        /// <list type="bullet">Name: Required, must be between 3 and <see cref="Constants.ProductNameMaxLength"/></list>
        /// <list type="bullet">Price: Required, must be greater than 0.0</list>
        /// <list type="bullet">Description: Required, must be between 3 and 200</list>
        /// <list type="bullet">Stock: Must be greater or equal to 0</list>
        /// </remarks>
        public UpdateProductCommandValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .Length(3, Constants.ProductNameMaxLength);

            RuleFor(product => product.Price)
               .GreaterThan(0m);

            RuleFor(product => product.Description)
                .NotEmpty()
                .Length(3, 200);

            RuleFor(product => product.Stock)
                .GreaterThanOrEqualTo(0);
        }
    }
}
