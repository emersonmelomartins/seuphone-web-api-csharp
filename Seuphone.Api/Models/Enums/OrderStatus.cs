using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Seuphone.Api.Models.Enums
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Aguardando")]
        AGUARDANDO,

        [EnumMember(Value = "Recebido")]
        RECEBIDO,

        [EnumMember(Value = "Cancelado")]
        CANCELADO,

    }
}
