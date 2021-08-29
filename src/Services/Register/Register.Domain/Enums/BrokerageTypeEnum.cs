using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Register.Domain.Enums
{
    public static class BrokerageTypeEnum
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum BrokerageType
        {
            [Description("Fixed")]
            Fixed = 0,

            [Description("Variable")]
            Variable = 1,

            [Description("Both")]
            Both = 2,
        }
    }
}