using BenchmarkDotNet.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmarks;

[MemoryDiagnoser(true)]
public class MediatorsBenchmarks
{
    private readonly MediatR.IMediator _mediatR;
    private readonly global::Mediator.IMediator _mediator;

    public MediatorsBenchmarks()
    {
        var mediatRServiceCollection = new ServiceCollection();
        mediatRServiceCollection.AddMediatR(configuration => configuration.AsTransient(), typeof(WebAPI.MediatR.Controllers.WeatherForecastController));
        var mediatRProvider = mediatRServiceCollection.BuildServiceProvider();
        _mediatR = mediatRProvider.GetRequiredService<MediatR.IMediator>();

        var mediatorServiceCollection = new ServiceCollection();
        mediatorServiceCollection.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Transient);
        var mediatorProvider = mediatorServiceCollection.BuildServiceProvider();
        _mediator = mediatorProvider.GetRequiredService<global::Mediator.IMediator>();
    }

    [Benchmark]
    public async Task WeatherMediatR()
    {
        var query = WebAPI.MediatR.Queries.GetWeatherForecastQuery.Instance;
        var result = await _mediatR.Send(query);
    }

    [Benchmark]
    public async Task WeatherMediator()
    {
        var query = WebAPI.Mediator.Queries.GetWeatherForecastQuery.Instance;
        var result = await _mediator.Send(query);
    }
}