using FluentValidationDotnetCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDotnetCore;

public interface IWeatherServices
{
    List<WeatherForecast> GetWeatherForeCasts();
    WeatherForecast PostWeatherForecast(WeatherForecast forecast);
}