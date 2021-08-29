using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Register.Domain.Enums
{
    public static class OrderTypeEnum
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum OrderType
        {
            [Description("Buy")]
            Buy = 0,

            [Description("Sell")]
            Sell = 1,
        }
    }
}