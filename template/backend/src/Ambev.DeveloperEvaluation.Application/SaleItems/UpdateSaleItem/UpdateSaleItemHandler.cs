using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem
{
    /// <summary>
    /// Handler for processing UpdateSaleItemCommand requests
    /// </summary>
    public class UpdateSaleItemHandler : IRequestHandler<UpdateSaleItemCommand, UpdateSaleItemResult>
    {
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UpdateSaleItemHandler
        /// </summary>
        /// <param name="saleItemRepository">The sale item repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public UpdateSaleItemHandler(ISaleItemRepository saleItemRepository,
            IMapper mapper)
        {
            _saleItemRepository = saleItemRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateSaleItemCommand request
        /// </summary>
        /// <param name="command">The UpdateSaleItem command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale item details</returns>
        public async Task<UpdateSaleItemResult> Handle(UpdateSaleItemCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleItemCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var saleItem = _mapper.Map<SaleItem>(command);

            var updatedSaleItem = await _saleItemRepository.UpdateAsync(saleItem, cancellationToken);

            if (updatedSaleItem == null)
            {
                throw new KeyNotFoundException($"SaleItem with ID {command.Id} not found");
            }

            var result = _mapper.Map<UpdateSaleItemResult>(updatedSaleItem);
            return result;
        }
    }
}