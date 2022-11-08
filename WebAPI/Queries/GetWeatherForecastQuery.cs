using MediatR;

namespace WebAPI.Queries;

public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
{
    public static GetWeatherForecastQuery Instance = new();
}
