using System;
using static Register.Domain.Enums.BrokerageTypeEnum;

namespace Register.Application.ViewModels
{
    public class StockBrokerVm
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public BrokerageType FeeType { get; set; }
        public double BrokerageValue { get; set; }
    }
}