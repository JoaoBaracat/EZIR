using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Register.Application.Features.OperationTypes.Commands.UpdateOperationType
{
    public class UpdateOperationTypeCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
    }
}