using Newtonsoft.Json;
using System;

namespace ApexClearing.SDK.Models.Response
{
    public class ErrorCodeResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("detailKeys")]
        public string[] DetailKeys { get; set; }
    }
}