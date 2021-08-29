using MediatR;
using Register.Application.ViewModels;
using System;

namespace Register.Application.Features.OperationTypes.Queries.GetOperationType
{
    public class GetOperationTypeQuery : IRequest<OperationTypeVm>
    {
        public Guid Id { get; set; }

        public GetOperationTypeQuery(Guid id)
        {
            Id = id;
        }
    }
}