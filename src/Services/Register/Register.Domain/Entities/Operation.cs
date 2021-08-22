using System;
using static Register.Domain.Enums.BrokerageTypeEnum;
using static Register.Domain.Enums.CostsTypeEnum;
using static Register.Domain.Enums.OrderTypeEnum;

namespace Register.Domain.Entities
{
    public class Operation : Entity
    {
        public Guid UserId { get; set; }
        public DateTime OperationDate { get; set; }
        public OrderType OrderType { get; set; }
        public int Quantity { get; set; }
        public string Ticker { get; set; }
        public double Price { get; set; }
        public CostsType CostsType { get; set; }

        public StockBroker StockBroker { get; set; }
        public BrokerageType FeeType { get; set; }

        public OperationType OperationType { get; set; }
    }
}