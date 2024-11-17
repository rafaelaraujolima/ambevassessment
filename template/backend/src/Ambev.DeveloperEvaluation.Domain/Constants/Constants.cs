namespace Ambev.DeveloperEvaluation.Domain.Constants
{
    public static class Constants
    {
        /// <summary>
        /// Gets the maximum length for the product name.
        /// </summary>
        public const int ProductNameMaxLength = 100;

        /// <summary>
        /// Gets the maximum length for the sale number.
        /// It's considering the pattern ABV_yyyyMMddHHmmss_SUFFIX:D5
        /// </summary>
        public const int SaleNumberMaxLength = 24;

        /// <summary>
        /// Gets the maximum quantity per item on a sale.
        /// </summary>
        public const int MaxQuantityPerItem = 20;
    }
}
