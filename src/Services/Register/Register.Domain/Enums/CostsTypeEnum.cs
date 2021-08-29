using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Register.Domain.Enums
{
    public static class CostsTypeEnum
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum CostsType
        {
            [Description("Brokerage + Fees")]
            BrokerageAndFees = 0,

            [Description("No brokerage")]
            NoBrokerage = 1,

            [Description("No fees")]
            NoFees = 2,

            [Description("No brokerage and no taxes")]
            NoBrokerageAndNoFees = 3
        }
    }
}