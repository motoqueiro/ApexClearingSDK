using ApexClearing.SDK.Models.Enums;
using Newtonsoft.Json;

namespace ApexClearing.SDK.Models.Response
{
    public class Quantity
    {
        /// <summary>
        /// The notional or fractional amount of the submitted order
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// One of: FRACTIONAL, NOTIONAL
        /// </summary>
        [JsonProperty("type")]
        public TradeType Type { get; set; }
    }
}
