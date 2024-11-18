﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Validator for DeleteSaleCommand
    /// </summary>
    public class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
    {
        /// <summary>
        /// Initializes validation rules for DeleteSaleCommand
        /// </summary>
        public DeleteSaleValidator() 
        {
            RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("Sale ID is required");
        }
    }
}