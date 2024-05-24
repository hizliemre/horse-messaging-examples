using Horse.Jockey;
using Horse.Messaging.Server;
using Horse.Server;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Devnot.Horse.Server;

internal sealed class HorseRiderService : IHostedService
{
    private readonly IOptions<JockeyOptions> _jockeyOptions;
    private readonly ILogger<HorseRiderService> _logger;
    private readonly HorseRiderBuilder _riderBuilder;
    private readonly HorseServer _server;

    public HorseRiderService(IOptions<ServerOptions> serverOptions, IOptions<JockeyOptions> jockeyOptions, ILogger<HorseRiderService> logger)
    {
        _logger = logger;
        _server = new HorseServer(serverOptions.Value);
        _jockeyOptions = jockeyOptions;
        _server.OnStarted += Started;
        _server.OnStopped += Stopped;
        _server.OnInnerException += ExceptionThrown;
        _riderBuilder = CreateHorseRiderBuilder();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        HorseRider rider = _riderBuilder.Build();
        rider.AddJockey(_jockeyOptions.Value);
        _server.UseRider(rider);
        _server.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _server.Stop();
        return Task.CompletedTask;
    }

    private static HorseRiderBuilder CreateHorseRiderBuilder()
    {
        return HorseRiderBuilder.Create().ConfigureQueues(cfg =>
        {
            cfg.UseMemoryQueues();
        });
    }

    private void Started(HorseServer obj)
    {
        _logger.LogInformation("[HORSE SERVER] Started");
    }

    private void Stopped(HorseServer obj)
    {
        _logger.LogInformation("[HORSE SERVER] Stopped");
    }

    private void ExceptionThrown(HorseServer server, Exception ex)
    {
        _logger.LogCritical(ex, "[ERROR] {Message}", ex.Message);
    }
}