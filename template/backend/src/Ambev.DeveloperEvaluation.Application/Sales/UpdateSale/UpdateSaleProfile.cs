﻿using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Profile for mapping between Sale entity and UpdateSaleResult
    /// </summary>
    public class UpdateSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateSale operation
        /// </summary>
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, Sale>();
            CreateMap<Sale, UpdateSaleResult>();
        }
    }
}
