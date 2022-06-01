using ApexClearing.SDK.Models.Enums;
using Newtonsoft.Json;

namespace ApexClearing.SDK.Models.Requests
{
    public class Fee
    {
        /// <summary>
        /// Valid FeeTypes include: CLIENT_CLEARING and GENERAL_PURPOSE
        /// </summary>
        [JsonProperty("feeType")]
        public FeeType Type { get; set; }

        /// <summary>
        /// Provides the fee amount
        /// </summary>
        [JsonProperty("feeAmount")]
        public decimal Amount { get; set; }
    }
}