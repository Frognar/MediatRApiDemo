using MediatR;

namespace WebAPI.MediatR.Queries;

public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
{
    public static GetWeatherForecastQuery Instance = new();
}