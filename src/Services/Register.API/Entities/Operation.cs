using System;
using static Register.API.Enums.BrokerageTypeEnum;
using static Register.API.Enums.CostsTypeEnum;
using static Register.API.Enums.OrderTypeEnum;

namespace Register.API.Entities
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