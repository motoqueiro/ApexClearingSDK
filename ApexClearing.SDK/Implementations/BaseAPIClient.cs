namespace ApexClearing.SDK.Implementations
{
    public class BaseAPIClient
    {
        public string APIUrl => UrlResolver.Resolve(UrlResolver.ApiEnvironment);
    }
}