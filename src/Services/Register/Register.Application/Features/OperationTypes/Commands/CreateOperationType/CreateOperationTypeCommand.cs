using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Register.Application.Features.OperationTypes.Commands.CreateOperationType
{
    public class CreateOperationTypeCommand : IRequest<Guid>
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}