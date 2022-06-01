using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApexClearing.SDK.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
    {
        /// <summary>
        /// A market order is an order that executes immediately at or near the current National Best Bid and Offer (NNBO). The NNBO is a quote that reports the highest bid price and lowest ask (offered) price in a security sourced from available exchanges and trading venues.
        /// </summary>
        [EnumMember(Value = "MARKET")]
        Market,

        /// <summary>
        /// A limit order is an order to buy or sell a stock at a specific price or better. Clients can only execute a buy limit order at the limit price or lower and a sell limit order at the limit price or higher.
        /// </summary>
        [EnumMember(Value = "LIMIT")]
        Limit
    }
}