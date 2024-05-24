using Horse.Messaging.Client.Queues;
using Horse.Messaging.Extensions.Client;
using Devnot.Queue.Producer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder();
hostBuilder.UseHorse(clientBuilder =>
{
    clientBuilder.AddHost("horse://localhost:16501");
});
IHost host = hostBuilder.Build();
_ = host.RunAsync();

IHorseQueueBus bus = host.Services.GetRequiredService<IHorseQueueBus>();
Console.Clear();

int messageCount = 1;

while (true)
{
    Console.WriteLine("Press any key to send a message");
    Console.ReadKey();
    TestMessageModel messageModel = new()
    {
        Foo = $"Hello DEVNOT {messageCount}",
    };
    messageCount++;
    await bus.PushJson(messageModel, true);
}

