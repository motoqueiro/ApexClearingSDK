using Newtonsoft.Json;

namespace ApexClearing.SDK.Models.Response
{

    public class OrderDetailResponse
    {
        /// <summary>
        /// Unique identifier for the order, provided by the client
        /// </summary>
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        /// <summary>
        /// Market date of the order placement
        /// </summary>
        [JsonProperty("tradeDate")]
        public string TradeDate { get; set; }

        /// <summary>
        /// Details about the status of the order
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }

        /// <summary>
        /// Details about any fill associated with the order, if any
        /// </summary>
        [JsonProperty("fill")]
        public Fill Fill { get; set; }

        /// <summary>
        /// Details about the submitted order
        /// </summary>
        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}