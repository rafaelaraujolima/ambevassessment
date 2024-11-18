using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem
{
    /// <summary>
    /// Profile for mapping between SaleItem entity and GetSaleItemResult
    /// </summary>
    public class GetSaleItemProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetSaleItem operation
        /// </summary>
        public GetSaleItemProfile()
        {
            CreateMap<SaleItem, GetSaleItemResult>();
        }
    }
}
