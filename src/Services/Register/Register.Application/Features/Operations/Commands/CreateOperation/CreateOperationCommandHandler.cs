using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Register.Applicatioin.Contracts.Persistence;
using Register.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Application.Features.Operations.Commands.CreateOperation
{
    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, Guid>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOperationCommandHandler> _logger;

        public CreateOperationCommandHandler(IOperationRepository operationRepository, IMapper mapper, ILogger<CreateOperationCommandHandler> logger)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            var operationToCreate = _mapper.Map<Operation>(request);
            var newOperation = await _operationRepository.CreateAsync(operationToCreate);

            _logger.LogInformation($"Operation {newOperation.Id} is successfully created.");

            return newOperation.Id;
        }
    }
}