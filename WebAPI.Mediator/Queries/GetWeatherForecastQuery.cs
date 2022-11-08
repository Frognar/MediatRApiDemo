using Mediator;

namespace WebAPI.Mediator.Queries;

public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
{
    public static GetWeatherForecastQuery Instance = new();
}
