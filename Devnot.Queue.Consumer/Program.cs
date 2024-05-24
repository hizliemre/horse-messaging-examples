using Horse.Messaging.Extensions.Client;
using Microsoft.Extensions.Hosting;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder();
hostBuilder.UseHorse(clientBuilder =>
{
    clientBuilder.AddHost("horse://localhost:16501");
    clientBuilder.AddTransientConsumers(typeof(Program));
});
IHost host = hostBuilder.Build();
host.Run();