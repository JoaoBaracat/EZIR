using System;
using static Register.API.Enums.BrokerageTypeEnum;

namespace Register.API.Entities
{
    public class StockBroker
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public BrokerageType FeeType { get; set; }
        public double BrokerageValue { get; set; }
    }
}