using ApexClearing.SDK.Models.Enums;
using Newtonsoft.Json;
using System;

namespace ApexClearing.SDK.Models.Response
{
    public class Order
    {
        /// <summary>
        /// The symbol of the instrument being traded
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// One of: BUY, SELL
        /// </summary>
        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("timeInForce")]
        public string TimeInForce { get; set; }

        /// <summary>
        /// One of: MARKET, LIMIT
        /// </summary>
        [JsonProperty("orderType")]
        public OrderType OrderType { get; set; }

        /// <summary>
        /// The limit price submitted with the order and should only be expected when the orderType is LIMIT
        /// </summary>
        [JsonProperty("limitPrice")]
        public decimal? LimitPrice { get; set; }

        /// <summary>
        /// Details about the order quantity
        /// </summary>
        [JsonProperty("quantity")]
        public Quantity Quantity { get; set; }

        [JsonProperty("accountDetails")]
        public AccountDetails AccountDetails { get; set; }

        /// <summary>
        /// Indicates the time the investor first submits the order
        /// </summary>
        [JsonProperty("receivedTime")]
        public DateTime? ClientOrderReceivedTime { get; set; }

        /// <summary>
        /// Indicates if the requestor makes the request on behalf of a client's affiliate
        /// </summary>
        [JsonProperty("affiliateOrder")]
        public bool AffiliateOrder { get; set; }
    }
}