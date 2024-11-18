namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    /// <summary>
    /// Represents a request to update a product in the system.
    /// </summary>
    public class UpdateProductRequest
    {
        /// <summary>
        /// The unique identifier of the product to delete
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the product name. Must not be empty.
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
    }
}
