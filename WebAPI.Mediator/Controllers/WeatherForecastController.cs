using Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAPI.Mediator.Queries;

namespace WebAPI.Mediator.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMediator _mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var result = await _mediator.Send(GetWeatherForecastQuery.Instance);
        _logger.LogInformation(JsonSerializer.Serialize(result));
        return result;
    }
}
