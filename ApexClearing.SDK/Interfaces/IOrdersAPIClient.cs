using ApexClearing.SDK.Models.Requests;
using ApexClearing.SDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApexClearing.SDK.Interfaces
{
    /// <summary>
    /// Submit orders for fractional or notional amounts. Orders system provides an interface for Apex clients to submit orders for equities and ETFs as notional dollar amounts or fractional share quantities.
    /// </summary>
    public interface IOrdersAPIClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> GetStatusAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IReadOnlyList<ErrorCodeResponse>> GetErrorCodesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrderResponse> InitiateOrderAsync(
            OrderRequest order,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Use this endpoint to retrieve the list of active symbols.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IReadOnlyList<string>> GetActiveSymbolsV1Async(CancellationToken cancellationToken = default);

        /// <summary>
        /// Use this endpoint to retrieve a list of symbols allowed for trading and a list of symbols allowed only for liquidation. Symbols in the "canLiquidate" list are available for SELL orders only to close out existing positions. Apex does not allow BUY orders for symbols in this list.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ActiveSymbolsResponse> GetActiveSymbolsV2Async(CancellationToken cancellationToken = default);

        /// <summary>
        /// Use this endpoint to retrieve detailed information about individual orders for investigative or troubleshooting purposes. For real-time updates on order state changes, order fills, and booking updates, Apex recommends using the Events service.
        /// </summary>
        /// <param name="tradeDate">Market date of the order placement</param>
        /// <param name="externalId">Unique identifier provided by the client</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OrderDetailResponse> GetOrderDetailsAsync(
            DateTime tradeDate,
            string externalId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// This endpoint cancels the order for the specified external ID. Users cannot cancel an order once the system fully fills the order. The system can only cancel orders with a tradeDate of the current date.
        /// </summary>
        /// <param name="tradeDate">Trade date for the order; in the format yyyy-MM-dd (must be the current date)</param>
        /// <param name="externalId">Unique identifier provided by the client</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task CancelOrderAsync(
            DateTime tradeDate,
            string externalId,
            CancellationToken cancellationToken = default);
    }
}