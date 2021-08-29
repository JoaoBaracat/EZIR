using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Register.Application.Features.Operations.Commands.DeleteOperation
{
    public class DeleteOperationCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}