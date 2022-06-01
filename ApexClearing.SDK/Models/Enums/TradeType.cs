using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApexClearing.SDK.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TradeType
    {
        /// <summary>
        /// A fractional trade occurs when the order quantity expresses as a decimal value of shares.
        /// </summary>
        [EnumMember(Value = "FRACTIONAL")]
        Fractional,

        /// <summary>
        /// A notional trade occurs when the order quantity expresses as the dollar value of the trade.
        /// </summary>
        [EnumMember(Value = "NOTIONAL")]
        Notional
    }
}