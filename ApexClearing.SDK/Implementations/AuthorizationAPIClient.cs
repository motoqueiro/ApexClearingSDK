using ApexClearing.SDK.Interfaces;
using ApexClearing.SDK.Models;
using ApexClearing.SDK.Models.Response;
using Flurl;
using Flurl.Http;
using Jose;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ApexClearing.SDK.UnitTests")]

namespace ApexClearing.SDK.Implementations
{
    internal class AuthorizationAPIClient
        : BaseAPIClient, IAuthorizationAPIClient
    {
        private readonly ClientCredentials _clientCredentials;

        public string Token { get; internal set; }

        public TokenInformationResponse TokenInformation { get; internal set; }

        internal AuthorizationAPIClient(ClientCredentials clientCredentials) => _clientCredentials = clientCredentials;

        public async Task<string> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            //Perform authentication if the token is null or expired
            if (string.IsNullOrEmpty(Token)
                || DateTime.UtcNow >= TokenInformation?.ExpiryTimeDate)
            {
                var jws = GenerateJWSFromClientCredentials();
                Token = await RequestJWTAccessTokenAsync(jws, cancellationToken);
                TokenInformation = await VerifyTokenAsync(cancellationToken);
            }

            return Token;
        }

        private Url JWTAccessTokenUrl => APIUrl.AppendPathSegments("legit", "api", "v1", "cc", "token");

        public async Task<string> RequestJWTAccessTokenAsync(
            string jws,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(jws))
            {
                throw new ArgumentNullException(nameof(jws));
            }

            return await JWTAccessTokenUrl
                .PostJsonAsync(
                    new
                    {
                        jws = jws
                    },
                    cancellationToken)
                .ReceiveString();
        }

        public async Task<TokenInformationResponse> VerifyTokenAsync(CancellationToken cancellationToken = default) => await APIUrl
            .AppendPathSegments("legit", "api", "v2", "verify")
            .WithHeader("Authorization", Token)
            .GetJsonAsync<TokenInformationResponse>(cancellationToken);

        public async Task InvalidateTokenAsync(CancellationToken cancellationToken = default) => await APIUrl
            .AppendPathSegments("legit", "api", "v1", "logout")
            .WithHeader("Authorization", Token)
            .GetAsync(cancellationToken);

        public string GenerateJWSFromClientCredentials()
        {
            var privateKey = Encoding.UTF8.GetBytes(_clientCredentials.SharedSecret);
            
            var options = JwtOptions.Default;
            options.EncodePayload = true;

            var bodyParameters = new Dictionary<string, object>
            {
                { "username", _clientCredentials.Username },
                { "entity", _clientCredentials.Entity },
                { "datetime", DateTime.UtcNow.ToString("o") }
            };

            return JWT.Encode(
                bodyParameters,
                privateKey,
                JwsAlgorithm.HS512,
                options: options);
        }

        public async Task EnsureAuthorizationHeaderAsync(
            FlurlCall call,
            CancellationToken cancellationToken = default)
        {
            if ((call.Request.Verb == HttpMethod.Post && Uri.Compare(call.Request.Url.ToUri(), JWTAccessTokenUrl.ToUri(), UriComponents.Host | UriComponents.Path, UriFormat.SafeUnescaped, StringComparison.OrdinalIgnoreCase) == 0)
                || call.Request.Headers.Contains("Authorization"))
            {
                return;
            }

            var token = await AuthenticateAsync(cancellationToken);
            call.Request.WithHeader("Authorization", token);
        }

        internal static ClientCredentials ReadCredentialsFile(string credentialsFilePath)
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