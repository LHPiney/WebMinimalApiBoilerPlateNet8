using Magnett.BoilerPlate.Core.Domain.Entities;

namespace Magnett.BoilerPlate.Core.Domain.Repositories;

public interface IWeatherForecastRepository
{
    public Task<IEnumerable<WeatherForecast>> GetAllAsync();
    public Task<WeatherForecast?> GetByIdAsync(int id);
}