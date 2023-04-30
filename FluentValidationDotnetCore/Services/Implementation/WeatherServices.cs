using FluentValidationDotnetCore.Extention;
using FluentValidationDotnetCore.Model;

namespace FluentValidationDotnetCore.Services.Implementation;


public class WeatherServices : IWeatherServices
{
    private readonly IServiceProvider _serviceProvider;

    public WeatherServices(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public List<WeatherForecast> GetWeatherForeCasts()
    {
        var summary = _serviceProvider.GetSummary();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summary[Random.Shared.Next(summary.Count)]
            })
            .ToList();
    }

    public WeatherForecast PostWeatherForecast(WeatherForecast forecast)
    {
        return forecast;
    }
}