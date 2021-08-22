using MediatR;
using Register.Application.ViewModels;
using System;

namespace Register.Application.Features.Operations.Queries.GetOperation
{
    public class GetOperationQuery : IRequest<OperationVm>
    {
        public Guid Id { get; set; }

        public GetOperationQuery(Guid id)
        {
            Id = id;
        }
    }
}