using ApexClearing.SDK.Interfaces;

namespace ApexClearing.SDK
{
    public interface IApexAPIClient
    {
        IAuthorizationAPIClient Authorization { get; }

        IOrdersAPIClient Orders { get; }
    }
}