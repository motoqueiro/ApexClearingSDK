using ApexClearing.SDK.Models;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace ApexClearing.SDK
{
    [Serializable]
    public class ApexException
        : Exception
    {
        public int? StatusCode { get; private set; }

        public ApexError Error { get; private set; }

        public ApexException()
        { }

        public ApexException(
            int? statusCode,
            Exception exception,
            ApexError apexError = null)
            : base(exception.Message, exception)
        {
            StatusCode = statusCode;
            Error = apexError;
        }

        public static async Task BuildFromAsync(FlurlHttpException flurlException)
        {
            var apexError = await flurlException.GetResponseJsonAsync<ApexError>();
            throw new ApexException(
                flurlException.StatusCode,
                flurlException,
                apexError);
        }

        internal static async Task BuildFromAsync(FlurlCall call)
        {
            var apexError = await call.Response?.GetJsonAsync<ApexError>();
            throw new ApexException(
                call.Response.StatusCode,
                call.Exception,
                apexError);
        }
    }
}