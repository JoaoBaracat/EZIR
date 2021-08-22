using AutoMapper;
using MediatR;
using Register.Applicatioin.Contracts.Persistence;
using Register.Application.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Register.Application.Features.Operations.Queries.GetOperation
{
    public class GetOperationQueryHandler : IRequestHandler<GetOperationQuery, OperationVm>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;

        public GetOperationQueryHandler(IOperationRepository operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        public async Task<OperationVm> Handle(GetOperationQuery request,
            CancellationToken cancellationToken)
        {
            var operation = await _operationRepository.GetByIdAsync(request.Id);
            return _mapper.Map<OperationVm>(operation);
        }
    }
}