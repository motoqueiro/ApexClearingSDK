using ApexClearing.SDK.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApexClearing.SDK.Models.Requests
{
    public class OrderRequest
    {
        /// <summary>
        /// Idempotent; 40-character limit; unique identifier provided by the client. Required
        /// </summary>
        [JsonProperty("externalID")]
        public string ExternalID { get; set; }

        /// <summary>
        /// Valid Apex account number. Required
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// CAT reporting Firm Designated ID; up to 40 alphanumeric characters; FDID (Firm Designated ID) must be the same for any single account, intra-day; for Apex-generated FDIDs, the field is optional; if the user omits this field, Apex generates a FDID; if using another FDID, users should submit it with each order for that account
        /// </summary>
        [JsonProperty("fdid")]
        public string FirmDesignatedID { get; set; }

        /// <summary>
        /// Valid symbol on the allow list. Required
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// BUY or SELL. Required
        /// </summary>
        [JsonProperty("side")]
        public Side Side { get; set; }

        /// <summary>
        /// FRACTIONAL OR NOTIONAL. Required
        /// </summary>
        [JsonProperty("quantityType")]
        public TradeType QuantityType { get; set; }

        /// <summary>
        /// For NOTIONAL orders, the value can extend two decimal places (e.g., 0.00); for FRACTIONAL orders, the value can extend five decimal places (e.g., 0.00000)
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Sets the maximum number of shares to sell on a NOTIONAL SELL order; the value must be greater than zero and can extend five decimal places (e.g., 0.00001) NOTE: Clients must omit or set this field as null on orders that are not `NOTIONAL SELL' or the system rejects the order.
        /// </summary>
        [JsonProperty("maxSellQuantity")]
        public decimal? MaxSellQuantity { get; set; }

        /// <summary>
        /// MARKET OR LIMIT. Orders with orderType omitted or set to null default to a MARKET order; the system rejects orders that have orderType set to LIMIT but do not include a valid limitPrice. NOTE: Because all orders placed through the Orders API have a day time in force, LIMIT orders are only valid for the trading day in which the user submits them
        /// </summary>
        [JsonProperty("orderType")]
        public OrderType? OrderType { get; set; }

        /// <summary>
        /// The limitPrice of the order to execute; Required when orderType = LIMIT; limitPrice must be > 0; limitPrice can extend to two decimal places(e.g., 1.00); omit or set as null for non-limit orders; the system rejects non-limit orders that include a limitPrice
        /// </summary>
        [JsonProperty("limitPrice")]
        public decimal? LimitPrice { get; set; }

        /// <summary>
        /// CAT reporting for the Account Holder Type; valid options include: INSTITUTIONAL, EMPLOYEE, FOREIGN, INDIVIDUAL, MARKET_MAKING, PROPRIETARY, ERROR, NOTE: Must be one of the specified enumerated values, but defaults to INDIVIDUAL if the user does not provide one; if the investor is not an individual, the user must supply the type of investor for each order for that account placed through the Orders API
        /// </summary>
        [JsonProperty("accountHolderType")]
        public AccountHolderType? AccountHolderType { get; set; }

        /// <summary>
        /// Bookkeeping instruction for the account type; valid options Include: CASH or MARGIN
        /// </summary>
        [JsonProperty("accountType")]
        public AccountType? AccountType { get; set; }

        /// <summary>
        /// Bookkeeping instruction for charges; contains charges.commissionAmount and fees
        /// </summary>
        [JsonProperty("charges")]
        public Charge Charges { get; set; }

        /// <summary>
        /// This parameter is only for FRACTIONAL orders; contains tradeDate, quantity, and price
        /// </summary>
        [JsonProperty("lotMatchingInstructions")]
        public List<LotMatchingInstruction> LotMatchingInstructions { get; set; }

        /// <summary>
        /// This CAT reporting field indicates when an investor first submits the order in ISO-8601 date and time; supports up to nanosecond precision
        /// </summary>
        [JsonProperty("clientOrderReceivedTime")]
        public DateTime? ClientOrderReceivedTime { get; set; }

        /// <summary>
        /// This CAT reporting field indicates if the order request is being made on behalf of the client's affiliate (true or false); default is false
        /// </summary>
        [JsonProperty("affiliateOrder")]
        public bool? AffiliateOrder { get; set; }
    }
}