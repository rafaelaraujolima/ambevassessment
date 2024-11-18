using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    /// <summary>
    /// Command for updating a product.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for updating a product, 
    /// including name, price, description, stock, status and the date of the last update. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="UpdateProductResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateProductCommandValidator"/> which extends 
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        /// <summary>
        /// The unique identifier of the product to update
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product stock.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets or sets the product status.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Initializes a new instance of UpdateProductCommand
        /// </summary>
        /// <param name="id">The ID of the product to update</param>
        public UpdateProductCommand(Guid id)
        {
            Id = id;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new UpdateProductCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
