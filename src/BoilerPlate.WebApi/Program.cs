using System.Text.Json.Serialization;
using Magnett.BoilerPlate.WebApi.Extensions;
using Magnett.BoilerPlate.WebApi.Models;

namespace Magnett.BoilerPlate.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });
        builder.Services.SetupWeatherForecast();
        
        var app = builder.Build();
        app.MapWeatherForecast();
        app.Run();
    }
}

[JsonSerializable(typeof(WeatherForecastDto))]
[JsonSerializable(typeof(IEnumerable<WeatherForecastDto>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}