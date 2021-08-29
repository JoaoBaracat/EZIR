using AutoMapper;
using MediatR;
using Register.Applicatioin.Contracts.Persistence;
using Register.Application.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Application.Features.OperationTypes.Queries.GetOperationType
{
    public class GetOperationTypeQueryHandler : IRequestHandler<GetOperationTypeQuery, OperationTypeVm>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IMapper _mapper;

        public GetOperationTypeQueryHandler(IOperationTypeRepository operationTypeRepository, IMapper mapper)
        {
            _operationTypeRepository = operationTypeRepository;
            _mapper = mapper;
        }

        public async Task<OperationTypeVm> Handle(GetOperationTypeQuery request,
            CancellationToken cancellationToken)
        {
            var operation = await _operationTypeRepository.GetByIdAsync(request.Id);
            return _mapper.Map<OperationTypeVm>(operation);
        }
    }
}