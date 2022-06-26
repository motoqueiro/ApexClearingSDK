using Newtonsoft.Json;
using System;
using System.IO;

namespace ApexClearing.SDK.Models
{
    public class ClientCredentials
    {
        /// <summary>
        /// The username value as provided in your credentials file
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>
        /// The entity value as provided in your credentials file
        /// </summary>
        [JsonProperty("entity")]
        public string Entity { get; private set; }

        /// <summary>
        /// The sharedSecret provided to you as part of your client credentials should be used as the private key for the hash. This binary hash is then base64 encoded for inclusion in the JWS string.
        /// </summary>
        [JsonProperty("sharedSecret")]
        public string SharedSecret { get; private set; }

        public ClientCredentials(
            string username,
            string entity,
            string sharedSecret)
        {
            Username = username;
            Entity = entity;
            SharedSecret = sharedSecret;
        }

        public static ClientCredentials BuildFromCredentialsFile(string credentialsFilePath)
        {
            if (string.IsNullOrWhiteSpace(credentialsFilePath))
            {
                throw new ArgumentNullException(nameof(credentialsFilePath));
            }

            using (var sr = new StreamReader(credentialsFilePath))
            {
                var json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<ClientCredentials>(json);
            }
        }
    }
}