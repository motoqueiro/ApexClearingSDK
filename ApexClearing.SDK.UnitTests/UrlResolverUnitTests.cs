using ApexClearing.SDK.Implementations;
using ApexClearing.SDK.Models.Enums;

namespace ApexClearing.SDK.UnitTests
{
    public class UrlResolverUnitTests
    {
        [Fact]
        public void UrlResolver_UATUrl_ShouldBeExpectedUrl()
        {
            //Act
            UrlResolver.UATUrl.Should().Be("https://uat-api.apexclearing.com");
        }

        [Fact]
        public void UrlResolver_ProductionUrl_ShouldBeExpectedUrl()
        {
            //Act
            UrlResolver.ProductionUrl.Should().Be("https://api.apexclearing.com");
        }

        [Theory]
        [InlineData(ApiEnvironment.Test, "https://uat-api.apexclearing.com")]
        [InlineData(ApiEnvironment.Production, "https://api.apexclearing.com")]
        public void UrlResolver_Resolve_ShouldReturnExpectedUrl(
            ApiEnvironment apiEnvironment,
            string expectedUrl)
        {
            //Act
            var url = UrlResolver.Resolve(apiEnvironment);

            //Assert
            url.Should().Be(expectedUrl);
        }

        [Fact]
        public void UrlResolver_Resolve_ShouldThrowException()
        {
            //Arrange
            var apiEnvironment = (ApiEnvironment)99;

            //Act
            var act = () => UrlResolver.Resolve(apiEnvironment);

            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Invalid api environment*")
                .WithParameterName("apiEnvironment");
        }
    }
}