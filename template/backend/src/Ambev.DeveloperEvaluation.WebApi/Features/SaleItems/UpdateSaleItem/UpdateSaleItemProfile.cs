using Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.UpdateSaleItem
{
    /// <summary>
    /// Profile for mapping between Application and API UpdateSaleItem responses
    /// </summary>
    public class UpdateSaleItemProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateSaleItem feature
        /// </summary>
        public UpdateSaleItemProfile()
        {
            CreateMap<UpdateSaleItemRequest, UpdateSaleItemCommand>();
            CreateMap<UpdateSaleItemResult, UpdateSaleItemResponse>();
        }
    }
}
