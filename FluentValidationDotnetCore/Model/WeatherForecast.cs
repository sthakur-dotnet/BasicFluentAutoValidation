using FluentValidation;
using static System.DateTime;

namespace FluentValidationDotnetCore.Model;

public class WeatherForecast
{
    public DateOnly Date { get; init; }

    public int TemperatureC { get; init; }

    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

    public string? Summary { get; init; }
}

public class WeatherForeCastValidator : AbstractValidator<WeatherForecast>
{
    public WeatherForeCastValidator()
    {
        RuleFor(_ => _.Summary).NotEmpty();
        RuleFor(_ => _.Date).GreaterThan(DateOnly.FromDateTime(DateTime.Now))
            .WithErrorCode("400").WithMessage("Date should be future");
        RuleFor(_ => _.TemperatureC).LessThan(80);
    }
}