using Newtonsoft.Json;

namespace ApexClearing.SDK.Models
{
    public class ApexError
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}