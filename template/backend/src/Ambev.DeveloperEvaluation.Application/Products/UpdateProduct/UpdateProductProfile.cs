using Ambev.DeveloperEvaluation.Domain.Entities.Product;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    /// <summary>
    /// Profile for mapping between Product entity and UpdateProductResult
    /// </summary>
    public class UpdateProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateProduct operation
        /// </summary>
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, UpdateProductResult>();
        }
    }
}
