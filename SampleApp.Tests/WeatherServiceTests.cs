using Xunit;
using Moq;
using FluentAssertions;
using SampleApp;

namespace SampleApp.Tests
{
    public class WeatherServiceTests
    {
        [Fact]
        public void DescribeTemperature_ReturnsHot_WhenTempAbove25()
        {
            var mockApi = new Mock<IWeatherApi>();
            mockApi.Setup(x => x.GetTemperature("Miami")).Returns(30);

            var service = new WeatherService(mockApi.Object);

            var result = service.DescribeTemperature("Miami");

            result.Should().Be("Hot");
        }

        [Fact]
        public void DescribeTemperature_ReturnsCold_WhenTemp25OrBelow()
        {
            var mockApi = new Mock<IWeatherApi>();
            mockApi.Setup(x => x.GetTemperature("Oslo")).Returns(10);

            var service = new WeatherService(mockApi.Object);

            var result = service.DescribeTemperature("Oslo");

            result.Should().Be("Cold");
        }
    }
}