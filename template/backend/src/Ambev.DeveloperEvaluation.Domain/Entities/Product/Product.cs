using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Product
{
    /// <summary>
    /// Represents a product in the system with information about the product.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets the unique identifier of the product.
        /// </summary>
        /// <returns>The products's ID as <see cref="string"/>.</returns>
        public string ProductId => Id.ToString();

        /// <summary>
        /// Gets the product name.
        /// Must not be null or empty or white space and should have more than 3 characters.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product price.
        /// Should be greater than 0.0.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the product description.
        /// Must not be null or empty or white space.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product stock.
        /// Must be greather than or equals to 0.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Gets the product status.
        /// </summary>
        /// <remarks>
        /// <listheader>Returns</listheader>
        /// <list type="bullet"><see langword="true"></see> : the product is active</list>
        /// <list type="bullet"><see langword="false"></see> : the product is not active</list>
        /// </remarks>
        public bool Status { get; set; }

        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the product's information.
        /// </summary>
        public DateTime LastUpdatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
