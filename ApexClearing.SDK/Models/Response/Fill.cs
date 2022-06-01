using Newtonsoft.Json;

namespace ApexClearing.SDK.Models.Response
{
    public class Fill
    {
        /// <summary>
        /// Total fractional shares allocated to the client
        /// </summary>
        [JsonProperty("shares")]
        public decimal Shares { get; set; }

        /// <summary>
        /// Average price for the fill
        /// </summary>
        [JsonProperty("averagePrice")]
        public string AveragePrice { get; set; }
    }
}
