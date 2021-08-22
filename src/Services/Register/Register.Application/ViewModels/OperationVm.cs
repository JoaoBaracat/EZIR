using System;
using static Register.Domain.Enums.BrokerageTypeEnum;
using static Register.Domain.Enums.CostsTypeEnum;
using static Register.Domain.Enums.OrderTypeEnum;

namespace Register.Application.ViewModels
{
    public class OperationVm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OperationDate { get; set; }
        public OrderType OrderType { get; set; }
        public int Quantity { get; set; }
        public string Ticker { get; set; }
        public double Price { get; set; }
        public CostsType CostsType { get; set; }

        public StockBrokerVm StockBroker { get; set; }
        public BrokerageType FeeType { get; set; }

        public OperationTypeVm OperationType { get; set; }
    }
}