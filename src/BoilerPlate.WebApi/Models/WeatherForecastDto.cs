using Magnett.BoilerPlate.Core.Domain.Entities;

namespace Magnett.BoilerPlate.WebApi.Models;

public record WeatherForecastDto(
    int Id,
    DateOnly Date,
    int TemperatureC,
    int TemperatureF,
    string? Summary)
{
    public static WeatherForecastDto Create(WeatherForecast forecast)
    {
        return new WeatherForecastDto
        (
            forecast.Id,
            forecast.Date,
            forecast.TemperatureC,
            forecast.TemperatureF,
            forecast.Summary
        );
    }
}