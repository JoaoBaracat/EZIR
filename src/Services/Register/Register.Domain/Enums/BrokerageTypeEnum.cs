﻿using System.ComponentModel;

namespace Register.Domain.Enums
{
    public static class BrokerageTypeEnum
    {
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