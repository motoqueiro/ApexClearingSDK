using ApexClearing.SDK.Implementations;
using ApexClearing.SDK.Interfaces;
using ApexClearing.SDK.Models;
using ApexClearing.SDK.Models.Enums;
using Flurl.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ApexClearing.SDK.UnitTests")]

namespace ApexClearing.SDK
{
    public class ApexAPIClient
        : BaseAPIClient, IApexAPIClient
    {
        public IAuthorizationAPIClient Authorization { get; private set; }

        public IOrdersAPIClient Orders { get; private set; }

        public ApexAPIClient(string credentialsFilePath, ApiEnvironment apiEnvironment = ApiEnvironment.Production)
            : this(AuthorizationAPIClient.ReadCredentialsFile(credentialsFilePath), apiEnvironment)
        { }

        public ApexAPIClient(
            ClientCredentials clientCredentials,
            ApiEnvironment apiEnvironment = ApiEnvironment.Production)
        {
            ChangeEnvironment(apiEnvironment);
            ConfigureHttpClient();
            Authorization = new AuthorizationAPIClient(clientCredentials);
            Orders = new OrdersAPIClient();
        }

        public void ChangeEnvironment(ApiEnvironment apiEnvironment) => UrlResolver.ApiEnvironment = apiEnvironment;

        internal void ConfigureHttpClient()
        {
            FlurlHttp.Configure(settings =>
            {
                settings.OnErrorAsync = HandleErrorAsync;
                settings.BeforeCallAsync = HandleBeforeCallAsync;
            });
        }

        private async Task HandleErrorAsync(FlurlCall call)
        {
            await ApexException.BuildFromAsync(call);
            call.ExceptionHandled = true;
        }

        private async Task HandleBeforeCallAsync(FlurlCall call) => await Authorization.EnsureAuthorizationHeaderAsync(call);
    }
}