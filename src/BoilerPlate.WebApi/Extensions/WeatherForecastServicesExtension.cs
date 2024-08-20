using Magnett.BoilerPlate.Core.Domain.Repositories;
using Magnett.BoilerPlate.Core.Domain.Services;
using Magnett.BoilerPlate.Core.Domain.Services.Abstractions;
using Magnett.BoilerPlate.Core.Infrastructure.InMemory;

namespace Magnett.BoilerPlate.WebApi.Extensions;

public static class WeatherForecastServicesExtension
{
    public static IServiceCollection SetupWeatherForecast(this IServiceCollection serviceCollection)
    {
        //Setup repositories
        serviceCollection.AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();

        //Setup services
        serviceCollection.AddScoped<IGetAllWeatherForecastService, GetAllWeatherForecastService>();
        serviceCollection.AddScoped<IGetWeatherForecastService, GetWeatherForecastService>();

        return serviceCollection;
    }
}