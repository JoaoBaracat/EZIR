using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Register.Applicatioin.Contracts.Persistence;
using Register.Application.Exceptions;
using Register.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Application.Features.Operations.Commands.CreateOperation
{
    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, Guid>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IStockBrokerRepository _stockBrokerRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOperationCommandHandler> _logger;

        public CreateOperationCommandHandler(IOperationRepository operationRepository, IMapper mapper, ILogger<CreateOperationCommandHandler> logger, IStockBrokerRepository stockBrokerRepository, IOperationTypeRepository operationTypeRepository)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
            _logger = logger;
            _stockBrokerRepository = stockBrokerRepository;
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<Guid> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
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

            var operationToCreate = _mapper.Map<Operation>(request);
            var newOperation = await _operationRepository.CreateAsync(operationToCreate);

            _logger.LogInformation($"Operation {newOperation.Id} was successfully created.");

            return newOperation.Id;
        }
    }
}