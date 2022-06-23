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
            <td>Generate JWS</td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>Request JWT</td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>Verify Token</td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>Logout / Invalidate Token</td>
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
            <td>Initiate an Order</td>
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
            <td>Retrieve A List of Active Symbols v1</td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>Retrieve A List of Active Symbols v2</td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>Get Order Details</td>
            <td>:heavy_check_mark:</td>
        </tr>
        <tr>
            <td>Cancel an Order</td>
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

The way to use the api can be found by consulting the integration tests at <https://github.com/motoqueiro/ApexClearingSDK/blob/main/ApexClearing.SDK.IntegrationTests/ApexClearingClientIntegrationTests.cs>