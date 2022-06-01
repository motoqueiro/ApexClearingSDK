using ApexClearing.SDK.Models.Response;
using Flurl.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApexClearing.SDK.Interfaces
{
    /// <summary>
    /// Create a JWT to access Apex APIs. Before you can start using Apex APIs, you will need access. This API provides two basic services: Authorization — managing a set of permissions for each user; and Authentication — verifying that a user or client is presenting valid credentials.
    /// </summary>
    public interface IAuthorizationAPIClient
    {
        string Token { get; }

        TokenInformationResponse TokenInformation { get; }

        Task<string> AuthenticateAsync(CancellationToken cancellationToken = default);

        Task EnsureAuthorizationHeaderAsync(FlurlCall call, CancellationToken cancellationToken = default);

        string GenerateJWSFromClientCredentials();

        /// <summary>
        /// This endpoint allows a client to invalidate an issued JWT access token. Once a JWT is invalidated, the token can no longer be used.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task InvalidateTokenAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// This endpoint allows an application to use a JWS to request a JWT access token, which is then used to authenticate the application's identity for requests to other Apex APIs.
        /// </summary>
        /// <param name="jws">The JWS signature, as described in Generating a JWS from Client Credentials</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> RequestJWTAccessTokenAsync(string jws, CancellationToken cancellationToken = default);

        /// <summary>
        /// The verify token endpoint is used to verify whether a token is valid and to retrieve information from valid tokens.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TokenInformationResponse> VerifyTokenAsync(CancellationToken cancellationToken = default);
    }
}