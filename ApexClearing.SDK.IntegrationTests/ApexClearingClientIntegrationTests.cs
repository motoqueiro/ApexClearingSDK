using ApexClearing.SDK.Models.Enums;

namespace ApexClearing.SDK.IntegrationTests
{
    public class ApexClearingClientIntegrationTests
    {
        private readonly ApexAPIClient _client;

        public ApexClearingClientIntegrationTests()
        {
            var apiEnvironment = ApiEnvironment.Test;
            var clientCredentialsPath = ResolveClientCredentialsPath(apiEnvironment);
            _client = new ApexAPIClient(
                clientCredentialsPath,
                apiEnvironment);
        }

        [Fact]
        public async Task ApexClearingAPIClient_Orders_GetStatusAsync_ShouldReturnTrue()
        {
            //Act
            var status = await _client.Orders.GetStatusAsync();

            //Arrange
            status.Should().BeTrue();
        }

        [Fact]
        public async Task ApexClearingAPIClient_Orders_GetErrorCodesAsync_ShouldReturnErrorCodes()
        {
            //Act
            var errorCodes = await _client.Orders.GetErrorCodesAsync();

            //Arrange
            errorCodes.Should().NotBeNullOrEmpty();
            foreach (var errorCode in errorCodes)
            {
                errorCode.Should().NotBeNull();
                errorCode.Code.Should().NotBeNullOrWhiteSpace();
                errorCode.Description.Should().NotBeNullOrWhiteSpace();
                errorCode.CreatedDate.Should().BeAfter(DateTime.MinValue);
            }
        }

        [Fact]
        public async Task ApexClearingAPIClient_Orders_GetActiveSymbolsV1Async_ShouldReturnSymbols()
        {
            //Act
            var activeSymbols = await _client.Orders.GetActiveSymbolsV1Async();

            //Arrange
            activeSymbols.Should().NotBeNull();
            activeSymbols.Should().OnlyHaveUniqueItems();
        }

        [Fact]
        public async Task ApexClearingAPIClient_Orders_GetActiveSymbolsV2Async_ShouldReturnSymbols()
        {
            //Act
            var activeSymbols = await _client.Orders.GetActiveSymbolsV2Async();

            //Arrange
            activeSymbols.Should().NotBeNull();
            activeSymbols.CanLiquidate.Should().OnlyHaveUniqueItems();
            activeSymbols.CanTrade.Should().OnlyHaveUniqueItems();
        }

        private static string ResolveClientCredentialsPath(ApiEnvironment apiEnvironment) => apiEnvironment switch
        {
            ApiEnvironment.Production => "client_credentials.production.json",
            _ => "client_credentials.test.json",
        };
    }
}