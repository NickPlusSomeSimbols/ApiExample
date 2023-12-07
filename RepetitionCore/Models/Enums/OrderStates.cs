using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepetitionCore.Models.Enums
{
    public enum OrderState : byte
    {
        Processing,
        Shipping,
        Delivered,
        Canceled
    }
}