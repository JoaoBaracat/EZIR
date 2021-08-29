using MediatR;
using Register.Application.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using static Register.Domain.Enums.BrokerageTypeEnum;
using static Register.Domain.Enums.CostsTypeEnum;
using static Register.Domain.Enums.OrderTypeEnum;

namespace Register.Application.Features.Operations.Commands.UpdateOperation
{
    public class UpdateOperationCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime OperationDate { get; set; }

        [Required]
        public OrderType OrderType { get; set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ticker { get; set; }

        [Required]
        [Range(0.00, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double Price { get; set; }

        [Required]
        public CostsType CostsType { get; set; }

        [Required]
        public Guid StockBrokerId { get; set; }

        [Required]
        public BrokerageType FeeType { get; set; }

        [Required]
        public Guid OperationTypeId { get; set; }
    }
}