using Horse.Messaging.Client.Channels.Annotations;

namespace Devnot.Channel.Listener1;

[ChannelName("channel-1")]
public class ChannelMessageModel
{
    public string Message { get; set; }
}