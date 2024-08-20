using Magnett.BoilerPlate.Core.Domain.Entities;

namespace Magnett.BoilerPlate.Core.Domain.Services.Abstractions;

public interface IGetWeatherForecastService
{
    public Task<WeatherForecast?> WithId(int id);
}