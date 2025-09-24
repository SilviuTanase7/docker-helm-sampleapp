using Xunit;
using FluentAssertions;
using SampleApp;

namespace SampleApp.Tests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void Add_ShouldReturnSum_WhenGivenTwoNumbers()
        {
            // Arrange
            var service = new CalculatorService();

            // Act
            var result = service.Add(2, 3);

            // Assert
            result.Should().Be(5);
        }
    }
}