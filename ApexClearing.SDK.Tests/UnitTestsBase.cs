using ApexClearing.SDK.Implementations;
using ApexClearing.SDK.Models;
using AutoFixture;
using Flurl.Http.Testing;
using Newtonsoft.Json;

namespace ApexClearing.SDK.UnitTests
{
    public class UnitTestsBase
    {
        internal readonly HttpTest _httpTest;

        internal readonly Fixture _fixture;

        public UnitTestsBase()
        {
            UrlResolver.ApiEnvironment = Models.Enums.ApiEnvironment.Test;
            _fixture = new Fixture();
            _httpTest = new HttpTest();
        }

        public void Dispose()
        {
            _httpTest.Dispose();
        }

        internal static string JWS => "eyJjdHkiOiJ0ZXh0XC9wbGFpbiIsImFsZyI6IkVTNTEyIn0.eyJ1c2VyX2VudGl0eSI6ImNvcnJlc3BvbmRlbnQuTFZPTCIsInVzZXJfaXAiOiIxMC4xODAuMTk5LjU4Iiwic3ViIjoic2VudGluZWwiLCJhdWQiOlsiYXBleGNsZWFyaW5nLmxvY2FsIl0sIm5iZiI6MTQyMjgyMTM2NywiaXNzIjoiYXBleGNsZWFyaW5nLmxvY2FsIiwidXNlcl9jbGFzcyI6IkNMSUVOVF9DUkVERU5USUFMU19VU0VSIiwiZXhwIjoxNDIyOTExNjY3LCJpYXQiOjE0MjI4MjE2NjcsImp0aSI6IjcwMjM5MDNkLWIyOWMtNGY4Ny04YzVlLWE1ZmQ4NGE5ZTQwZSJ9.AfQojKB0VHpgVFlgwgNqsDwg0wwveLoNc4mK7nzY-IOxNj3YlWEVRQTUzqAathHVbl1mURA8yaz4dhyrE-jkthqGAI5bsjg14GTOEN3T1fnvm6PThlkrhbCaaxHfYms0p9RlAJtLIMx1SOlsKANu0gZ9HoIg4MHZgNZMC0Fpdj-TE9K\\";

        internal static string JWT => "eyJjdHkiOiJ0ZXh0XC9wbGFpbiIsImFsZyI6IkVTNTEyIn0.eyJ1c2VyX2VudGl0eSI6ImFwZXhjbGVhcmluZy5sb2NhbCIsInVzZXJfaXAiOiIxMC4xODAuOC4yMDciLCJzdWIiOiJwc2NobWl0eiIsImF1ZCI6WyJhcGV4Y2xlYXJpbmcubG9jYWwiXSwibmJmIjoxNjAwNzMyNzYwLCJpc3MiOiJhcGV4Y2xlYXJpbmcubG9jYWwiLCJ1c2VyX2NsYXNzIjoiQUNUSVZFX0RJUkVDVE9SWV9VU0VSIiwiZXhwIjoxNjAwNzQwMjYwLCJpYXQiOjE2MDA3MzMwNjAsImp0aSI6IjU5NjAyNGVlLWVjZDYtNGYwMS05ZmIzLTFjNzBmMmE5NjI2MCJ9.ABlkQZt9JJm40gCnL4p3dcFW7GTrpU_6LwihKdORT6ZO6yodOx0LPBaLlfvIAe02Mx7i_9upwVLlTicTfQxSZ32ARbjXrjY2sfsZhf55OUTrW5HLhkAWx45vG2pAYs1e211W7FcsGfRYdoC2HAgcgE8_DWm0ahWoGrApwnTQFbMGuKS";

        internal static string ClientCredentialsFilePath => "client_credentials.json";

        internal static ClientCredentials ClientCredentials => AuthorizationAPIClient.ReadCredentialsFile(ClientCredentialsFilePath);

        internal T LoadRequestFromFile<T>(string filePath)
        {
            var json = LoadRequestFromFile(filePath);
            return ConvertFromJson<T>(json);
        }

        internal string LoadRequestFromFile(string filePath) => LoadFromFile(Path.Combine("Requests", filePath));

        internal T LoadResponseFromFile<T>(string filePath)
        {
            var json = LoadResponseFromFile(filePath);
            return ConvertFromJson<T>(json);
        }

        internal string LoadResponseFromFile(string filePath) => LoadFromFile(Path.Combine("Responses", filePath));

        internal string LoadFromFile(string filePath)
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }

        internal T ConvertFromJson<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}