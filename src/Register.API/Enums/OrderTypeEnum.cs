﻿using System.ComponentModel;

namespace Register.API.Enums
{
    public static class OrderTypeEnum
    {
        public enum OrderType
        {
            [Description("Buy")]
            Buy = 0,

            [Description("Sell")]
            Sell = 1,
        }
    }
}