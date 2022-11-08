using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebAPI.MediatR.Queries;

namespace WebAPI.MediatR.Controllers;
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
