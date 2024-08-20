using Magnett.BoilerPlate.Core.Domain.Entities;
using Magnett.BoilerPlate.Core.Domain.Repositories;
using Magnett.BoilerPlate.Core.Domain.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace Magnett.BoilerPlate.Core.Domain.Services;

public class GetWeatherForecastService(
    IWeatherForecastRepository weatherForecastRepository,
    ILogger<GetWeatherForecastService> logger)
    : IGetWeatherForecastService
{
    private readonly IWeatherForecastRepository _weatherForecastRepository = weatherForecastRepository 
                                                                             ?? throw new ArgumentNullException(nameof(weatherForecastRepository));
    private readonly ILogger _logger = logger 
                                       ?? throw new ArgumentNullException(nameof(logger));

    public async Task<WeatherForecast?> WithId(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        
        try
        {
            return await _weatherForecastRepository.GetByIdAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Error getting weather forecast");
            throw;
        }
    }
}