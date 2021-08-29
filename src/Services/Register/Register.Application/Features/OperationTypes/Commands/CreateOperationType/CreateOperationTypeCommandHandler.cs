using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Register.Applicatioin.Contracts.Persistence;
using Register.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Application.Features.OperationTypes.Commands.CreateOperationType
{
    public class CreateOperationTypeCommandHandler : IRequestHandler<CreateOperationTypeCommand, Guid>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOperationTypeCommandHandler> _logger;

        public CreateOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository, IMapper mapper, ILogger<CreateOperationTypeCommandHandler> logger)
        {
            _operationTypeRepository = operationTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationTypeToCreate = _mapper.Map<OperationType>(request);
            var newOperationType = await _operationTypeRepository.CreateAsync(operationTypeToCreate);

            _logger.LogInformation($"Operation Type {newOperationType.Id} was successfully created.");

            return newOperationType.Id;
        }
    }
}