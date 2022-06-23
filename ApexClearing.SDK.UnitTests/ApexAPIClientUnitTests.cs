namespace ApexClearing.SDK.UnitTests
{
    internal class ApexAPIClientUnitTests
    {
        private readonly ApexAPIClient _client;

        public ApexAPIClientUnitTests() => _client = new ApexAPIClient(ClientCredentialsPath);

        private string ClientCredentialsPath => "client_credentials.json";
    }
}