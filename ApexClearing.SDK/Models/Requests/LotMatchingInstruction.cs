using Newtonsoft.Json;
using System;

namespace ApexClearing.SDK.Models.Requests
{
    public class LotMatchingInstruction
    {
        /// <summary>
        /// Date and time of trade
        /// </summary>
        [JsonProperty("tradeDate")]
        public DateTime TradeDate { get; set; }

        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Price of trade; if the user provides more than one instruction, then the user cannot include the price
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; set; }
    }
}