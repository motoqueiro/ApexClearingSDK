using ApexClearing.SDK.Models.Enums;
using System;

namespace ApexClearing.SDK.Implementations
{
    public static class UrlResolver
    {
        public const string UATUrl = "https://uat-api.apexclearing.com";

        public const string ProductionUrl = "https://api.apexclearing.com";

        internal static ApiEnvironment ApiEnvironment = ApiEnvironment.Production;

        public static string Resolve(ApiEnvironment apiEnvironment)
        {
            switch (apiEnvironment)
            {
                case ApiEnvironment.Test:
                    return UATUrl;

                case ApiEnvironment.Production:
                    return ProductionUrl;

                default:
                    throw new ArgumentOutOfRangeException("apiEnvironment", "Invalid api environment");
            }
        }
    }
}