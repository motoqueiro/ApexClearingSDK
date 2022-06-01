using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApexClearing.SDK.Models.Requests
{
    public class Charge
    {
        /// <summary>
        /// The Orders API currently only supports commissionAmount as a valid decimal field
        /// </summary>
        [JsonProperty("commissionAmount")]
        public decimal CommissionAmount { get; set; }

        /// <summary>
        /// Fee types and amounts; contains feeType and feeAmount
        /// </summary>
        [JsonProperty("fees")]
        public List<Fee> Fees { get; set; }
    }
}