using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem
{
    /// <summary>
    /// Profile for mapping between SaleItem entity and CreateSaleItemResult
    /// </summary>
    public class CreateSaleItemProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSaleItem operation
        /// </summary>
        public CreateSaleItemProfile()
        {
            CreateMap<CreateSaleItemCommand, SaleItem>();
            CreateMap<SaleItem, CreateSaleItemResult>();
        }
    }
}
