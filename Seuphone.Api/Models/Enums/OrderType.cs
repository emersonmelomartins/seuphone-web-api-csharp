using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Seuphone.Api.Models.Enums
{
    public enum OrderType
    {
        [EnumMember(Value = "Entrada")]
        IN = 1,
        [EnumMember(Value = "Saída")]
        OUT = 2,
        [EnumMember(Value = "Todos")]
        ALL = 3,
    }
}
