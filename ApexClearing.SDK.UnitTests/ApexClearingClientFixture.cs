using ApexClearing.SDK.Implementations;
using ApexClearing.SDK.Models;
using ApexClearing.SDK.Models.Enums;
using Flurl.Http.Testing;

namespace ApexClearing.SDK.UnitTests
{
    public class ApexClearingClientFixture
        : IDisposable
    {
        //internal readonly ApexAPIClient apexClient;

        internal readonly HttpTest httpTest;

        public ApexClearingClientFixture()
        {
            /*apexClient = new ApexAPIClient(
                ClientCredentials,
                ApiEnvironment.Test);*/
            UrlResolver.ApiEnvironment = ApiEnvironment.Test;
            httpTest = new HttpTest();
            ConfigureHttpMockResponses();
        }

        

        

        public void Dispose() => httpTest.Dispose();

        
    }
}