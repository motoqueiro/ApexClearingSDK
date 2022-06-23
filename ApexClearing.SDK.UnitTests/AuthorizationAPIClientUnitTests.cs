using ApexClearing.SDK.Implementations;
using ApexClearing.SDK.Models.Response;

namespace ApexClearing.SDK.UnitTests
{
    public class AuthorizationAPIClientUnitTests
        : UnitTestsBase, IDisposable
    {
        private readonly AuthorizationAPIClient _authorizationClient;

        public AuthorizationAPIClientUnitTests()
            : base()
        {
            _authorizationClient = new AuthorizationAPIClient(ClientCredentials);
        }

        [Fact]
        public void AuthorizationAPIClient_ReadCredentialsFile_ShouldReturnClientCredentials()
        {
            //Act
            var clientCredentials = AuthorizationAPIClient.ReadCredentialsFile(ClientCredentialsFilePath);

            //Assert
            clientCredentials.Should().NotBeNull();
            clientCredentials.Username.Should().Be("apex_api");
            clientCredentials.Entity.Should().Be("correspondent.ETRO");
            clientCredentials.SharedSecret.Should().Be("tRfZfS6k327DUd1KRCrsnjvhIxoGOaS-qUtTjxoGX48cTXdOpRHGIPrHhvsyM_L3rNjH22qNKMUs6lKHuPR8bQ");
        }

        [Fact]
        public void UnitTests_AuthorizationAPIClient_GenerateJWSFromClientCredentials()
        {
            //Act
            var jws = _authorizationClient.GenerateJWSFromClientCredentials();

            //Assert
            jws.Should().NotBeNull();
        }

        [Fact]
        public async Task UnitTests_AuthorizationAPIClient_AuthenticateAsync()
        {
            //Act
            var jwt = await _authorizationClient.AuthenticateAsync();

            //Assert
            jwt.Should().NotBeNull();
        }

        [Fact]
        public async Task UnitTests_AuthorizationAPIClient_RequestJWTAccessTokenAsync_ShouldReturnToken()
        {
            //Arrange
            _httpTest.ForCallsTo("https://*api.apexclearing.com/legit/api/v1/cc/token")
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(
                    new
                    {
                        jws = JWS
                    })
                .RespondWith(
                    JWT,
                    200,
                    new
                    {
                        ContentType = "application/octet-stream"
                    });

            //Act
            var token = await _authorizationClient.RequestJWTAccessTokenAsync(JWS);

            //Assert
            token.Should().Be(JWT);
        }

        //[Fact]
        //public async Task UnitTests_AuthorizationAPIClient_RequestJWTAccessTokenAsync_Error401_ShouldThrowApexException()
        //{
        //    //Arrange
        //    var jws = "test401";
        //    _fixture.httpTest.ForCallsTo("https://uat-api.apexclearing.com/legit/api/v1/cc/token")
        //        .WithVerb(HttpMethod.Post)
        //        .WithRequestJson(
        //            new
        //            {
        //                jws = jws
        //            })
        //        .RespondWith(string.Empty, 401);

        //    //Act
        //    var act = async () => await _fixture.apexClient.Authorization.RequestJWTAccessTokenAsync(jws);

        //    //Assert
        //    var exception = (await act.Should().ThrowAsync<ApexException>()).And;
        //    exception.StatusCode.Should().Be(401);
        //    exception.Error.Should().BeNull();
        //}

        //[Fact]
        //public async Task UnitTests_AuthorizationAPIClient_RequestJWTAccessTokenAsync_Error500_ShouldThrowApexException()
        //{
        //    //Arrange
        //    var jws = "test500";
        //    _fixture.httpTest.ForCallsTo("https://uat-api.apexclearing.com/legit/api/v1/cc/token")
        //        .WithVerb(HttpMethod.Post)
        //        .WithRequestJson(
        //            new
        //            {
        //                jws = jws
        //            })
        //        .RespondWithJson(new { error = "server error", message = null as string }, 500);

        //    //Act
        //    var act = async () => await _fixture.apexClient.Authorization.RequestJWTAccessTokenAsync(jws);

        //    //Assert
        //    var exception = (await act.Should().ThrowAsync<ApexException>()).And;
        //    exception.StatusCode.Should().Be(500);
        //    exception.Error.Should().NotBeNull();
        //    exception.Error.Error.Should().Be("server error");
        //    exception.Error.Message.Should().BeNull();
        //}

        [Fact]
        public async Task UnitTests_AuthorizationAPIClient_VerifyTokenAsync_ShouldReturnTokenInformation()
        {
            //Arrange
            var expectedTokenInformation = LoadResponseFromFile<TokenInformationResponse>("Verify_Token_Response.json");
            _httpTest.ForCallsTo("https://*api.apexclearing.com/legit/api/v2/verify")
                .WithVerb(HttpMethod.Get)
                .WithHeader("Authorization", JWT)
                .RespondWithJson(
                    expectedTokenInformation,
                    200);
            _authorizationClient.Token = JWT;

            //Act
            var tokenInformation = await _authorizationClient.VerifyTokenAsync();

            //Assert
            tokenInformation.Should().BeEquivalentTo(expectedTokenInformation);
        }

        //[Fact]
        //public async Task UnitTests_AuthorizationAPIClient_VerifyTokenAsync_ShouldThrowApexException()
        //{
        //    //Arrange
        //    _fixture.httpTest.ForCallsTo("http://uat-public-api.apexclearing.com/legit/api/v2/verify")
        //        .WithVerb(HttpMethod.Get)
        //        .RespondWithJson(
        //        new
        //        {
        //            error = "not authorized",
        //            message = null as string
        //        },
        //        401);

        //    //Act
        //    var act = async () => await _authorizationClient.VerifyTokenAsync();

        //    //Assert
        //    var exception = (await act.Should().ThrowAsync<ApexException>()).And;
        //    exception.StatusCode.Should().Be(401);
        //    exception.Error.Should().NotBeNull();
        //    exception.Error.Error.Should().Be("not authorized");
        //    exception.Error.Message.Should().BeNull();
        //}

        [Fact]
        public async Task UnitTests_AuthorizationAPIClient_InvalidateTokenAsync_ShouldNotThrowException()
        {
            //Arrange
            _httpTest.ForCallsTo("https://*api.apexclearing.com/legit/api/v1/logout")
                .WithVerb(HttpMethod.Get)
                .WithHeader("Authorization", JWT)
                .RespondWith();
            _authorizationClient.Token = JWT;

            //Act
            await _authorizationClient.InvalidateTokenAsync();
        }

        //[Fact]
        //public async Task UnitTests_AuthorizationAPIClient_InvalidateTokenAsync_Error500_ShouldThrowApexException()
        //{
        //    //Arrange
        //    var jws = "xpto";
        //    _fixture.httpTest.ForCallsTo("https://uat-api.apexclearing.com/legit/api/v1/logout")
        //        .WithVerb(HttpMethod.Get)
        //        .WithHeader("Authorization", jws)
        //        .RespondWithJson(new { error = "BadRequest", message = "jwt not provided" }, 400);

        //    //Act
        //    var act = async () => await _fixture.apexClient.Authorization.InvalidateTokenAsync();

        //    //Assert
        //    var exception = (await act.Should().ThrowAsync<ApexException>()).And;
        //    exception.StatusCode.Should().Be(400);
        //    exception.Error.Should().NotBeNull();
        //    exception.Error.Error.Should().Be("BadRequest");
        //    exception.Error.Message.Should().Be("jwt not provided");
        //}
    }
}