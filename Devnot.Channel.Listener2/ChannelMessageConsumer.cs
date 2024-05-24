using Devnot.Channel.Listener2;
using Horse.Messaging.Client;
using Horse.Messaging.Client.Channels;
using Horse.Messaging.Protocol;

namespace Devnot.Channel.Listener2;

public class ChannelMessageConsumer:IChannelSubscriber<ChannelMessageModel>
{
    public async Task Handle(ChannelMessageModel model, HorseMessage rawMessage, HorseClient client)
    {
        await Console.Out.WriteLineAsync(model.Message);
    }

    public Task Error(Exception exception, ChannelMessageModel model, HorseMessage rawMessage, HorseClient client) => throw new NotImplementedException();
}