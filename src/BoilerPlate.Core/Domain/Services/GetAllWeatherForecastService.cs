using Magnett.BoilerPlate.Core.Domain.Entities;
using Magnett.BoilerPlate.Core.Domain.Repositories;
using Magnett.BoilerPlate.Core.Domain.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace Magnett.BoilerPlate.Core.Domain.Services;

public class GetAllWeatherForecastService(
    IWeatherForecastRepository weatherForecastRepository,
    ILogger<GetAllWeatherForecastService> logger) : IGetAllWeatherForecastService
{ 
    private readonly IWeatherForecastRepository _weatherForecastRepository = weatherForecastRepository
                                                                             ?? throw new ArgumentNullException(nameof(weatherForecastRepository));
    private readonly ILogger _logger = logger 
                                       ?? throw new ArgumentNullException(nameof(logger));

    public async Task<IEnumerable<WeatherForecast>> Do()
    {
        try
        {
            return await _weatherForecastRepository.GetAllAsync();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Error getting all weather forecast");
            throw;
        }
    }

}