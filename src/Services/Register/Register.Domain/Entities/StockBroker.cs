using static Register.Domain.Enums.BrokerageTypeEnum;

namespace Register.Domain.Entities
{
    public class StockBroker : Entity
    {
        public UserConfiguration User { get; set; }
        public string Name { get; set; }
        public BrokerageType FeeType { get; set; }
        public double BrokerageValue { get; set; }
    }
}