using Devnot.Message.Sender;
using Horse.Messaging.Client.Direct;
using Horse.Messaging.Extensions.Client;
using Horse.Messaging.Protocol;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder();
hostBuilder.UseHorse(clientBuilder => { clientBuilder.AddHost("horse://localhost:16501"); });
IHost host = hostBuilder.Build();
_ = host.RunAsync();

IHorseDirectBus bus = host.Services.GetRequiredService<IHorseDirectBus>();

int messageCount = 1;

Console.Clear();
while (true)
{
    Console.WriteLine("Press any key to send a message");
    Console.ReadKey();
    RequestMessage requestMessage = new()
    {
        Number = messageCount
    };
    messageCount++;

    HorseResult<ResponseMessage> result = await bus.RequestJsonAsync<ResponseMessage>(requestMessage);
    if (result.Code == HorseResultCode.Ok)
        await Console.Out.WriteLineAsync(result.Model.Square.ToString());
    else
        await Console.Out.WriteLineAsync($"Error: {result.Reason}");
}