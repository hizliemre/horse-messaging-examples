using Devnot.Channel.Distributor;
using Horse.Messaging.Client.Channels;
using Horse.Messaging.Extensions.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder();
hostBuilder.UseHorse(clientBuilder => { clientBuilder.AddHost("horse://localhost:16501"); });
IHost host = hostBuilder.Build();
_ = host.RunAsync();

IHorseChannelBus bus = host.Services.GetRequiredService<IHorseChannelBus>();
Console.Clear();

int messageCount = 1;
while (true)
{
    Console.WriteLine("Press any key to send a message");
    Console.ReadKey();
    ChannelMessageModel messageModel = new()
    {
        Message = $"Hello DEVNOT {messageCount}"
    };
    messageCount++;
    await bus.Publish(messageModel);
}