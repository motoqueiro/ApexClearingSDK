# ApexClearingSDK
.Net client SDK to work with [Apex Clearing API](https://developer.apexclearing.com/apexclearing/reference/getting-started).

The resources/functionalities supported are listed on the following table:

<table>
    <thead>
        <tr>
            <th>Resources</th>
            <th>Endpoints</th>
            <th>Support</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td rowspan=4>
                <a href="https://developer.apexclearing.com/apexclearing/reference/authorization-main" target="_blank">Authorization</a>
            </td>
            <td>
                <a href="https://developer.apexclearing.com/apexclearing/reference/authorization-main#generating-a-jws-from-client-credentials" target="_blank">Generate JWS</a>
            </td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>
                <a href="https://developer.apexclearing.com/apexclearing/reference/authorization-main#section-request-a-jwt-access-token" target="_blank">Request JWT</a>
            </td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>
                <a href="https://developer.apexclearing.com/apexclearing/reference/authorization-main#verify-a-token" target="_blank">Verify Token</a>
            </td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>
                <a href="https://developer.apexclearing.com/apexclearing/reference/authorization-main#logout--invalidate-a-token" target="_blank">Logout / Invalidate Token</a>
            </td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td colspan=2>Events</td>
            <td>:x:</td>
        </tr>
        <tr>
            <td colspan=2>Accounts</td>
            <td>:x:</td>
        </tr>
        <tr>
            <td colspan=2>Cash</td>
            <td>:x:</td>
        </tr>
        <tr>
            <td colspan=2>Portfolios</td>
            <td>:x:</td>
        </tr>
        <tr>
            <td colspan=2>Trading</td>
            <td>:x:</td>
        </tr>
        <tr>
            <td rowspan=7>
                <a href="https://developer.apexclearing.com/apexclearing/reference/orders-main" target="_blank">Orders</a>
            </td>
            <td>
                <a href="https://developer.apexclearing.com/apexclearing/reference/orders-main#initiate-an-order" target="_blank">Initiate an Order</a>
            </td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>Retrieve Status</td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>Retrieve A List of Error Codes</td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>
                <a href="https://developer.apexclearing.com/apexclearing/reference/orders-main#retrieve-a-list-of-active-symbols-v1" target="_blank">Retrieve A List of Active Symbols v1</a>
            </td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>
                <a href="https://developer.apexclearing.com/apexclearing/reference/orders-main#retrieve-a-list-of-active-symbols-v2" target="_blank">Retrieve A List of Active Symbols v2</a>
            </td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>
                <a href="https://developer.apexclearing.com/apexclearing/reference/orders-main#get-order-details" target="_blank">Get Order Details</a>
            </td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>
                <a href="https://developer.apexclearing.com/apexclearing/reference/orders-main#cancel-an-order" target="_blank">Cancel an Order</a>
            </td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td colspan=2>Transfers</td>
            <td>:x:</td>
        </tr>
        <tr>
            <td colspan=2>Lending</td>
            <td>:x:</td>
        </tr>
        <tr>
            <td colspan=2>Crypto</td>
            <td>:x:</td>
        </tr>
    </tbody>
</table>

## Samples

```
var clientCredentials = new ClientCredentials
{
    Username = Environment.GetEnvironmentVariable("APEXCLEARING_USERNAME"),
    Entity = Environment.GetEnvironmentVariable("APEXCLEARING_ENTITY"),
    SharedSecret = Environment.GetEnvironmentVariable("APEXCLEARING_SHAREDSECRET")
};
var client = new ApexAPIClient(clientCredentials);
var status = await _client.Orders.GetStatusAsync();
```

More examples can be found by consulting the integration tests at <https://github.com/motoqueiro/ApexClearingSDK/blob/main/ApexClearing.SDK.IntegrationTests/ApexClearingClientIntegrationTests.cs>