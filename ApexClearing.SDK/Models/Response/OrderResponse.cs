using ApexClearing.SDK.Models.Enums;
using Newtonsoft.Json;

namespace ApexClearing.SDK.Models.Response
{
    public class OrderResponse
    {
        /// <summary>
        /// If the request is successful, this value prints PENDING and is the only response field the system returns
        /// </summary>
        [JsonProperty("status")]
        public StatusType Status { get; internal set; }

        /// <summary>
        /// If the request response is REJECTED, an additional REASON field states the reason for the rejection
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; internal set; }
    }
}
