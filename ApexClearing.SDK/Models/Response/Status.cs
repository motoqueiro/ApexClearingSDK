using ApexClearing.SDK.Models.Enums;
using Newtonsoft.Json;
using System;

namespace ApexClearing.SDK.Models.Response
{
    public class Status
    {
        /// <summary>
        /// Status code
        /// </summary>
        [JsonProperty("code")]
        public StatusType Code { get; set; }

        /// <summary>
        /// Date and time this status occurred; ISO-8601
        /// </summary>
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// Additional information about the reason for the status
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
