using Horse.Messaging.Extensions.Client;
using Microsoft.Extensions.Hosting;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder();
hostBuilder.UseHorse(clientBuilder =>
{
    clientBuilder
        .AddHost("horse://localhost:16501")
        .SetClientType("message-receiver")
        .AddTransientDirectHandlers(typeof(Program));
});
IHost host = hostBuilder.Build();
host.Run();