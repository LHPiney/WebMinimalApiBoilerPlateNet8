using Magnett.BoilerPlate.Core.Domain.Entities;

namespace Magnett.BoilerPlate.Core.Domain.Services.Abstractions;

public interface IGetAllWeatherForecastService
{
    public  Task<IEnumerable<WeatherForecast>> Do();
}