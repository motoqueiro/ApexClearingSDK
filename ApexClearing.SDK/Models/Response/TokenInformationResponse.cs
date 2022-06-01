using Newtonsoft.Json;
using System;

namespace ApexClearing.SDK.Models.Response
{
    public class TokenInformationResponse
    {
        /// <summary>
        /// The entity the token was issued for
        /// </summary>
        [JsonProperty("user_entity")]
        public string UserEntity { get; set; }

        /// <summary>
        /// The client IP the token was issued to
        /// </summary>
        [JsonProperty("user_ip")]
        public string UserIp { get; set; }

        /// <summary>
        /// The subject; the user for whom the JWT was issued
        /// </summary>
        [JsonProperty("sub")]
        public string Subject { get; set; }

        /// <summary>
        /// The audience; who the token is intended for
        /// </summary>
        [JsonProperty("aud")]
        public string[] Audience { get; set; }

        /// <summary>
        /// The not before time, before which the token is not valid. Formatted as a UNIX timestamp of seconds since the UNIX epoch
        /// </summary>
        [JsonProperty("nbf")]
        public long NotBeforeTime { get; set; }

        public DateTime NotBeforeTimeDate => DateTimeOffset.FromUnixTimeSeconds(NotBeforeTime).DateTime;

        /// <summary>
        /// The issuer who created and signed this token
        /// </summary>
        [JsonProperty("iss")]
        public string Issuer { get; set; }

        /// <summary>
        /// The class of user
        /// </summary>
        [JsonProperty("user_class")]
        public string UserClass { get; set; }

        /// <summary>
        /// The expiry time, after which the token is not valid. Formatted as a UNIX timestamp of seconds since the UNIX epoch
        /// </summary>
        [JsonProperty("exp")]
        public long ExpiryTime { get; set; }

        public DateTime ExpiryTimeDate => DateTimeOffset.FromUnixTimeSeconds(ExpiryTime).DateTime;

        /// <summary>
        /// The issued at time, when the token was issued. Formatted as a UNIX timestamp of seconds since the UNIX epoch
        /// </summary>
        [JsonProperty("iat")]
        public long IssuedAtTime { get; set; }

        public DateTime IssuedAtTimeDate => DateTimeOffset.FromUnixTimeSeconds(IssuedAtTime).DateTime;

        /// <summary>
        /// The JWT ID; a unique ID for this token
        /// </summary>
        [JsonProperty("jti")]
        public string JWTId { get; set; }
    }
}