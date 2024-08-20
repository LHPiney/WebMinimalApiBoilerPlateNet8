using Magnett.BoilerPlate.Core.Domain.Services.Abstractions;
using Magnett.BoilerPlate.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Magnett.BoilerPlate.WebApi.Extensions;

public static class WeatherForecastMapExtension
{
    private static void MapGetAll(RouteGroupBuilder app)
    {
        app.MapGet("/", async ([FromServices] IGetAllWeatherForecastService getAllWeatherForecastService) =>
    
            await getAllWeatherForecastService.Do() is { } weatherForecasts
                ? Results.Ok(weatherForecasts.Select(WeatherForecastDto.Create))
                : Results.NotFound())
            .WithName("GetAllWeatherForecast")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary     = "Get All Weather Forecasts",
                Description = "Returns information about all weather forecasts.",
                Tags        = new List<OpenApiTag> { new() { Name = "Weather Forecast" } }
            });
    }
    private static void MapGetById(RouteGroupBuilder app)
    {
        app.MapGet("/{id}", async ([FromServices] IGetWeatherForecastService getWeatherForecastService, int id) =>
           await getWeatherForecastService.WithId(id) is { } weatherForecast
                ? Results.Ok(WeatherForecastDto.Create(weatherForecast))
                : Results.NotFound())
            .WithName("GetWeatherForecast")
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary     = "Get Weather Forecast",
                Description = "Returns information about the weather forecast for the given id.",
                Tags        = new List<OpenApiTag> { new() { Name = "Weather Forecast" } }
            });
    }
    
    public static WebApplication MapWeatherForecast(this WebApplication app)
    {
        var weatherForecastApi = app.MapGroup("/weatherforecast");

        MapGetAll(weatherForecastApi);
        MapGetById(weatherForecastApi);

        return app;
    }
}

