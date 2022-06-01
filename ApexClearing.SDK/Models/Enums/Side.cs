using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApexClearing.SDK.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Side
    {
        [EnumMember(Value = "BUY")]
        Buy,

        [EnumMember(Value = "SELL")]
        Sell
    }
}