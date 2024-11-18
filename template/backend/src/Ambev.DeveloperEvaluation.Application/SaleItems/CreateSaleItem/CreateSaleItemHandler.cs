using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem
{
    /// <summary>
    /// Handler for processing CreateSaleItemCommand requests
    /// </summary>
    public class CreateSaleItemHandler : IRequestHandler<CreateSaleItemCommand, CreateSaleItemResult>
    {
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateSaleItemHandler
        /// </summary>
        /// <param name="saleItemRepository">The sale item repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateSaleItemHandler(ISaleItemRepository saleItemRepository,
            IMapper mapper)
        {
            _saleItemRepository = saleItemRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateSaleItemCommand request
        /// </summary>
        /// <param name="command">The CreateSaleItem command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        public async Task<CreateSaleItemResult> Handle(CreateSaleItemCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleItemCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var saleItem = _mapper.Map<SaleItem>(command);

            var createdSaleItem = await _saleItemRepository.CreateAsync(saleItem, cancellationToken);
            var result = _mapper.Map<CreateSaleItemResult>(createdSaleItem);
            return result;
        }
    }
}
