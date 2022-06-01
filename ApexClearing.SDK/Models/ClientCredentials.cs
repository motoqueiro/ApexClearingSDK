using Newtonsoft.Json;

namespace ApexClearing.SDK.Models
{
    public class ClientCredentials
    {
        /// <summary>
        /// The username value as provided in your credentials file
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The entity value as provided in your credentials file
        /// </summary>
        [JsonProperty("entity")]
        public string Entity { get; set; }

        /// <summary>
        /// The sharedSecret provided to you as part of your client credentials should be used as the private key for the hash. This binary hash is then base64 encoded for inclusion in the JWS string.
        /// </summary>
        [JsonProperty("sharedSecret")]
        public string SharedSecret { get; set; }
    }
}