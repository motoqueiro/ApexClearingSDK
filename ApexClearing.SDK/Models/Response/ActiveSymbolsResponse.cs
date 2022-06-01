using Newtonsoft.Json;

namespace ApexClearing.SDK.Models.Response
{
    public class ActiveSymbolsResponse
    {
        /// <summary>
        /// Array of symbols active for trading (BUY and SELL)
        /// </summary>
        [JsonProperty("canTrade")]
        public string[] CanTrade { get; set; }

        /// <summary>
        /// Array of symbols active for liquidation only (SELL only)
        /// </summary>
        [JsonProperty("canLiquidate")]
        public string[] CanLiquidate { get; set; }
    }
}