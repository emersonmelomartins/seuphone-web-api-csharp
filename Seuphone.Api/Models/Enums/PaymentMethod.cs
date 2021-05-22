using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Seuphone.Api.Models.Enums
{
    public enum PaymentMethod
    {
        [EnumMember(Value = "Cartão de Crédito")]
        CARTAO_DE_CREDITO = 1,

        [EnumMember(Value = "Carnê")]
        CARNE = 2,
    }
}
