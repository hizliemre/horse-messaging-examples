using Horse.Messaging.Client;
using Horse.Messaging.Client.Queues;
using Horse.Messaging.Client.Queues.Annotations;
using Horse.Messaging.Protocol;

namespace Devnot.Queue.Consumer;

[AutoAck]
[AutoNack(NegativeReason.Error)]
internal class TestMessageModelConsumer : IQueueConsumer<TestMessageModel>
{
    public async Task Consume(HorseMessage message, TestMessageModel model, HorseClient client)
    {
        await Console.Out.WriteLineAsync(model.Foo);
    }
}