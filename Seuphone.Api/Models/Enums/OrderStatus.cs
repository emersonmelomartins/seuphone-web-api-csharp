using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Seuphone.Api.Models.Enums
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        [EnumMember(Value = "Aguardando")]
        AGUARDANDO,

        [EnumMember(Value = "Recebido")]
        RECEBIDO,

    }
}
