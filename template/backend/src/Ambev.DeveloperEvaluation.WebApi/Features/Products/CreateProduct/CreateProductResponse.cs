namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    /// <summary>
    /// API response model for CreateProduct operation
    /// </summary>
    public class CreateProductResponse
    {
        /// <summary>
        /// The unique identifier of the product
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The product's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The product's price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The product's description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The product's stock
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// The product's status
        /// </summary>
        public bool Status { get; set; }
    }
}
