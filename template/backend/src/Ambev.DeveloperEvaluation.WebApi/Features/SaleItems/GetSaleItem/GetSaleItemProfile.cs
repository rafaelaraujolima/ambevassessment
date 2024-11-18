﻿using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem
{
    /// <summary>
    /// Profile for mapping GetSaleItem feature requests to commands
    /// </summary>
    public class GetSaleItemProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetSaleItem feature
        /// </summary>
        public GetSaleItemProfile()
        {
            CreateMap<Guid, GetSaleItemCommand>()
                .ConstructUsing(id => new GetSaleItemCommand(id));

            CreateMap<GetSaleItemResult, GetSaleItemResponse>();
        }

    }
}
