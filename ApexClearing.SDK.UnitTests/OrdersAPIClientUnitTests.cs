using ApexClearing.SDK.Implementations;
using ApexClearing.SDK.Models.Requests;
using ApexClearing.SDK.Models.Response;
using AutoFixture.Xunit2;

namespace ApexClearing.SDK.UnitTests
{
    public class OrdersAPIClientUnitTests
        : UnitTestsBase
    {
        private readonly OrdersAPIClient _ordersClient;

        public OrdersAPIClientUnitTests()
            : base() => _ordersClient = new OrdersAPIClient();

        [Fact]
        public async Task OrdersAPIClient_GetActiveSymbolsV1Async_ShouldReturnActiveSymbols()
        {
            //Arrange
            var expectedActiveSymbols = LoadResponseFromFile<string[]>("Get_Active_Symbols_V1_Response.json");
            _httpTest.ForCallsTo("https://*api.apexclearing.com/fractional-trading/api/v1/symbol")
                .WithVerb(HttpMethod.Get)
                .RespondWithJson(expectedActiveSymbols);

            //Act
            var activeSymbols = await _ordersClient.GetActiveSymbolsV1Async();

            //Assert
            activeSymbols.Should().BeEquivalentTo(expectedActiveSymbols);
        }

        [Fact]
        public async Task OrdersAPIClient_GetActiveSymbolsV2Async_ShouldReturnActiveSymbols()
        {
            //Arrange
            var expectedActiveSymbols = LoadResponseFromFile<ActiveSymbolsResponse>("Get_Active_Symbols_V2_Response.json");
            _httpTest.ForCallsTo("https://*api.apexclearing.com/fractional-trading/api/v2/symbol")
                .WithVerb(HttpMethod.Get)
                .RespondWithJson(expectedActiveSymbols);

            //Act
            var activeSymbols = await _ordersClient.GetActiveSymbolsV2Async();

            //Assert
            activeSymbols.Should().BeEquivalentTo(expectedActiveSymbols);
        }

        [Theory]
        [InlineData("Initiate_Order_Basic_Fractional_Buy_Request.json", "Initiate_Order_Status_Response.json")]
        [InlineData("Initiate_Order_Fractional_Sell_Request.json", "Initiate_Order_Status_Response.json")]
        [InlineData("Initiate_Order_Fractional_Buy_Rejected_Request.json", "Initiate_Order_Rejected_Response.json")]
        [InlineData("Initiate_Order_Notational_Buy_Request.json", "Initiate_Order_Status_Response.json")]
        public async Task OrdersAPIClient_InitiateOrderAsync(
            string requestFilePath,
            string responseFilePath)
        {
            //Arrange
            var request = LoadRequestFromFile<OrderRequest>(requestFilePath);
            var expectedResponse = LoadResponseFromFile<OrderResponse>(responseFilePath);
            _httpTest.ForCallsTo("https://*api.apexclearing.com/fractional-trading/api/v1/orders")
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(request)
                .RespondWithJson(expectedResponse);

            //Act
            var response = await _ordersClient.InitiateOrderAsync(request);

            //Assert
            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Theory]
        [InlineData("2020-12-17", "504d7915-eadd-4897-a7e7-da3045fb25aa", "Get_Order_Details_Successful_Response.json")]
        [InlineData("2020-12-17", "504d7915-eadd-4897-a7e7-da3045fb25aa", "Get_Order_Details_Pending_Response.json")]
        public async Task OrdersAPIClient_GetOrderDetailsAsync_ShouldReturnOrderDetails(
            string tradeRaw,
            string externalId,
            string responseFilePath)
        {
            //Arrange
            var tradeDate = DateTime.Parse(tradeRaw);
            var expectedResponse = LoadResponseFromFile<OrderDetailResponse>(responseFilePath);
            _httpTest.ForCallsTo($"https://*api.apexclearing.com/fractional-trading/api/v1/orders/{tradeRaw}/{externalId}")
                .WithVerb(HttpMethod.Get)
                .RespondWithJson(expectedResponse);

            //Act
            var orderDetails = await _ordersClient.GetOrderDetailsAsync(
                tradeDate,
                externalId);

            //Assert
            orderDetails.Should().BeEquivalentTo(expectedResponse);
        }

        [Theory, AutoData]
        public async Task OrdersAPIClient_CancelOrderAsync_ShouldNotThrowException(
            DateTime tradeDate,
            string externalId)
        {
            //Arrange
            _httpTest.ForCallsTo($"https://*api.apexclearing.com/fractional-trading/api/v1/orders/{tradeDate.ToString("yyyy-MM-dd")}/{externalId}:cancel")
                .WithVerb(HttpMethod.Post)
                .RespondWith(status: 202);

            //Act
            await _ordersClient.CancelOrderAsync(
                tradeDate,
                externalId);
        }
    }
}