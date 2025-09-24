var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello from Sample .NET App running in Docker!");

app.RunAsync();

namespace SampleApp
{
    public class CalculatorService
    {
        public int Add(int a, int b) => a + b;
    }
}

namespace SampleApp
{
    public interface IWeatherApi
    {
        int GetTemperature(string city);
    }

    public class WeatherService
    {
        private readonly IWeatherApi _api;
        public WeatherService(IWeatherApi api) => _api = api;

        public string DescribeTemperature(string city)
        {
            var temp = _api.GetTemperature(city);
            return temp > 25 ? "Hot" : "Cold";
        }
    }
}
