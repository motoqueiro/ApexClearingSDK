using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApexClearing.SDK.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountType
    {
        [EnumMember(Value = "CASH")]
        Cash,

        [EnumMember(Value = "MARGIN")]
        Margin,

        [EnumMember(Value = "SHORT")]
        Short
    }
}