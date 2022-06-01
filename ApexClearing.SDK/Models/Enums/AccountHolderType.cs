using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApexClearing.SDK.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountHolderType
    {
        [EnumMember(Value = "INSTITUTIONAL")]
        Institutional,

        [EnumMember(Value = "EMPLOYEE")]
        Employee,

        [EnumMember(Value = "FOREIGN")]
        Foreign,

        [EnumMember(Value = "INDIVIDUAL")]
        Individual,

        [EnumMember(Value = "MARKET_MAKING")]
        MarketMaking,

        [EnumMember(Value = "PROPRIETARY")]
        Proprietary,

        [EnumMember(Value = "ERROR")]
        Error,
    }
}