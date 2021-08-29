using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Register.Applicatioin.Contracts.Persistence;
using Register.Application.Exceptions;
using Register.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Application.Features.Operations.Commands.DeleteOperation
{
    public class DeleteOperationCommandHandler : IRequestHandler<DeleteOperationCommand>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOperationCommandHandler> _logger;

        public DeleteOperationCommandHandler(IOperationRepository operationRepository, IMapper mapper, ILogger<DeleteOperationCommandHandler> logger, IStockBrokerRepository stockBrokerRepository, IOperationTypeRepository operationTypeRepository)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
        {
            var operationToDelete = await _operationRepository.GetByIdAsync(request.Id);
            if (operationToDelete is null)
            {
                throw new NotFoundException(nameof(Operation), request.Id);
            }

            await _operationRepository.DeleteAsync(operationToDelete);

            _logger.LogInformation($"Operation {operationToDelete.Id} was successfully deleted.");

            return Unit.Value;
        }
    }
}