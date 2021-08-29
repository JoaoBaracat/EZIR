using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Register.Applicatioin.Contracts.Persistence;
using Register.Application.Exceptions;
using Register.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Application.Features.Operations.Commands.UpdateOperation
{
    public class UpdateOperationCommandHandler : IRequestHandler<UpdateOperationCommand>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IStockBrokerRepository _stockBrokerRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOperationCommandHandler> _logger;

        public UpdateOperationCommandHandler(IOperationRepository operationRepository, IMapper mapper, ILogger<UpdateOperationCommandHandler> logger, IStockBrokerRepository stockBrokerRepository, IOperationTypeRepository operationTypeRepository)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
            _logger = logger;
            _stockBrokerRepository = stockBrokerRepository;
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<Unit> Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
        {
            var operationToUpdate = await _operationRepository.GetByIdAsync(request.Id);
            if (operationToUpdate is null)
            {
                throw new NotFoundException(nameof(Operation), request.Id);
            }

            var stockBroker = await _stockBrokerRepository.GetByIdAsync(request.StockBrokerId);
            if (stockBroker is null)
            {
                throw new NotFoundException(nameof(StockBroker), request.StockBrokerId);
            }

            var operationType = await _operationTypeRepository.GetByIdAsync(request.OperationTypeId);
            if (operationType is null)
            {
                throw new NotFoundException(nameof(OperationType), request.OperationTypeId);
            }

            _mapper.Map(request, operationToUpdate, typeof(UpdateOperationCommand), typeof(Operation));
            await _operationRepository.UpdateAsync(operationToUpdate);

            _logger.LogInformation($"Operation {operationToUpdate.Id} was successfully updated.");

            return Unit.Value;
        }
    }
}