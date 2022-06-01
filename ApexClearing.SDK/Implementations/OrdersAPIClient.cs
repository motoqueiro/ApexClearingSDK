using ApexClearing.SDK.Interfaces;
using ApexClearing.SDK.Models.Requests;
using ApexClearing.SDK.Models.Response;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ApexClearing.SDK.UnitTests")]

namespace ApexClearing.SDK.Implementations
{
    public class OrdersAPIClient
        : BaseAPIClient, IOrdersAPIClient
    {
        public async Task<OrderResponse> InitiateOrderAsync(
            OrderRequest order,
            CancellationToken cancellationToken = default)
        {
            if (order == null)
            {
                throw new ArgumentNullException();
            }

            return await APIUrl.AppendPathSegments("fractional-trading", "api", "v1", "orders")
                .PostJsonAsync(
                    order,
                    cancellationToken)
                .ReceiveJson<OrderResponse>();
        }

        public async Task<bool> GetStatusAsync(CancellationToken cancellationToken = default)
        {
            var response = await APIUrl
                .AppendPathSegments("fractional-trading", "api", "status")
                .GetAsync(cancellationToken);
            return response.StatusCode == (int)HttpStatusCode.OK;
        }

        public async Task<IReadOnlyList<ErrorCodeResponse>> GetErrorCodesAsync(CancellationToken cancellationToken = default) => await APIUrl
            .AppendPathSegments("fractional-trading", "api", "v1", "error_codes")
            .GetJsonAsync<List<ErrorCodeResponse>>(cancellationToken);

        public async Task<IReadOnlyList<string>> GetActiveSymbolsV1Async(CancellationToken cancellationToken = default) => await APIUrl
            .AppendPathSegments("fractional-trading", "api", "v1", "symbol")
            .GetJsonAsync<List<string>>(cancellationToken);

        public async Task<ActiveSymbolsResponse> GetActiveSymbolsV2Async(CancellationToken cancellationToken = default) => await APIUrl
            .AppendPathSegments("fractional-trading", "api", "v2", "symbol")
            .GetJsonAsync<ActiveSymbolsResponse>(cancellationToken);

        public async Task<OrderDetailResponse> GetOrderDetailsAsync(
            DateTime tradeDate,
            string externalId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(externalId))
            {
                throw new ArgumentNullException(nameof(externalId));
            }

            return await APIUrl
                .AppendPathSegments("fractional-trading", "api", "v1", "orders", tradeDate.ToString("yyyy-MM-dd"), externalId)
                .GetJsonAsync<OrderDetailResponse>(cancellationToken: cancellationToken);
        }

        public async Task CancelOrderAsync(
            DateTime tradeDate,
            string externalId,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(externalId))
            {
                throw new ArgumentNullException(nameof(externalId));
            }

            await APIUrl
                .AppendPathSegments("fractional-trading", "api", "v1", "orders", tradeDate.ToString("yyyy-MM-dd"), externalId, "cancel")
                .PostAsync(cancellationToken: cancellationToken);
        }
    }
}