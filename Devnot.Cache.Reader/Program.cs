using Horse.Messaging.Client.Cache;
using Horse.Messaging.Extensions.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder();
hostBuilder.UseHorse(clientBuilder => { clientBuilder.AddHost("horse://localhost:16501"); });
IHost host = hostBuilder.Build();
_ = host.RunAsync();

IHorseCache cache = host.Services.GetRequiredService<IHorseCache>();
Console.Clear();

while (true)
{
    Console.WriteLine("Enter cache key:");
    var key = Console.ReadLine();
    var data = await cache.Get<string>(key);
    Console.WriteLine(data.Value);
}