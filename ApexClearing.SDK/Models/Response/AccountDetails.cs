using ApexClearing.SDK.Models.Enums;
using Newtonsoft.Json;

namespace ApexClearing.SDK.Models.Response
{
    public class AccountDetails
    {
        /// <summary>
        /// One of: CASH, MARGIN, SHORT
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }

        /// <summary>
        /// One of: FRACTIONAL, NOTIONAL
        /// </summary>
        [JsonProperty("accountType")]
        public AccountType AccountType { get; set; }

        /// <summary>
        /// One of: INSTITUTIONAL, EMPLOYEE, FOREIGN, INDIVIDUAL, MARKET_MAKING, AVERAGE_PRICE, PROPRIETARY
        /// </summary>
        [JsonProperty("accountHolderType")]
        public AccountHolderType AccountHolderType { get; set; }

        /// <summary>
        /// The Firm Designated ID used for CAT reporting
        /// </summary>
        [JsonProperty("fdid")]
        public string FirmDesignatedID { get; set; }
    }
}