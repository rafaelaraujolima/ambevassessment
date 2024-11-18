using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem
{
    /// <summary>
    /// Profile for mapping between SaleItem entity and UpdateSaleItemResult
    /// </summary>
    public class UpdateSaleItemProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateSaleItem operation
        /// </summary>
        public UpdateSaleItemProfile()
        {
            CreateMap<UpdateSaleItemCommand, SaleItem>();
            CreateMap<SaleItem, UpdateSaleItemResult>();
        }
    }
}
