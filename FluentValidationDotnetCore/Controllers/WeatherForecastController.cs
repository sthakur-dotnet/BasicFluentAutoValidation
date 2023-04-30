using FluentValidationDotnetCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDotnetCore.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly IWeatherServices _weatherServices;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherServices weatherServices)
    {
        _logger = logger;
        _weatherServices = weatherServices;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        var forecasts = _weatherServices.GetWeatherForeCasts();
        if (!forecasts.Any()) return NotFound();
        return Ok(forecasts);
    }
    
    [HttpPost(Name = "PostWeatherForecast")]
    public IActionResult Post(WeatherForecast forecast)
    {
        return Ok(_weatherServices.PostWeatherForecast(forecast));
    }
}