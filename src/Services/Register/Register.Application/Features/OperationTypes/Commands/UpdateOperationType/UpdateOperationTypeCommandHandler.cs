using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Register.Applicatioin.Contracts.Persistence;
using Register.Application.Exceptions;
using Register.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Application.Features.OperationTypes.Commands.UpdateOperationType
{
    public class UpdateOperationTypeCommandHandler : IRequestHandler<UpdateOperationTypeCommand>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOperationTypeCommandHandler> _logger;

        public UpdateOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository, IMapper mapper, ILogger<UpdateOperationTypeCommandHandler> logger)
        {
            _operationTypeRepository = operationTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationTypeToUpdate = await _operationTypeRepository.GetByIdAsync(request.Id);
            if (operationTypeToUpdate is null)
            {
                throw new NotFoundException(nameof(OperationType), request.Id);
            }

            _mapper.Map(request, operationTypeToUpdate, typeof(UpdateOperationTypeCommand), typeof(OperationType));
            await _operationTypeRepository.UpdateAsync(operationTypeToUpdate);

            _logger.LogInformation($"Operation Type {operationTypeToUpdate.Id} was successfully updated.");

            return Unit.Value;
        }
    }
}