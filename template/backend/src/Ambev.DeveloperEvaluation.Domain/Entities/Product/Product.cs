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
        /// <returns>The name.</returns>
        public string Name { get; set; }

        /// <summary>
        /// Gets the product price.
        /// Should be greater than 0.0.
        /// </summary>
        /// <returns>The price.</returns>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the product description.
        /// Must not be null or empty or white space.
        /// </summary>
        /// <returns>The description.</returns>
        public string Description { get; set; }

        /// <summary>
        /// Gets the product stock.
        /// Must be greather than or equals to 0.
        /// </summary>
        /// <returns>The stock.</returns>
        public int Stock { get; set; }

        /// <summary>
        /// Gets the product status.
        /// </summary>
        /// <returns>The status.</returns>
        /// <remarks>
        /// <listheader>Returns</listheader>
        /// <list type="bullet"><see langword="true"></see> : the product is active</list>
        /// <list type="bullet"><see langword="false"></see> : the product is not active</list>
        /// </remarks>
        public bool Status { get; set; }

        /// <summary>
        /// Gets the date of creation of the product.
        /// </summary>
        /// <returns>The date that it was created.</returns>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date of the last update of the product.
        /// </summary>
        /// <returns>The date that it was last updated.</returns>
        public DateTime LastUpdatedAt { get; set; }
    }
}
