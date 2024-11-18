﻿using Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.DeleteSaleItem
{
    /// <summary>
    /// Profile for mapping DeleteSaleItem feature requests to commands
    /// </summary>
    public class DeleteSaleItemProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for DeleteSaleItem feature
        /// </summary>
        public DeleteSaleItemProfile()
        {
            CreateMap<Guid, DeleteSaleItemCommand>()
                .ConstructUsing(id => new DeleteSaleItemCommand(id));
        }
    }
}