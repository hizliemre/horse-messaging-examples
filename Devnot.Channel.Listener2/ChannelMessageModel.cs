using Horse.Messaging.Client.Channels.Annotations;

namespace Devnot.Channel.Listener2;

[ChannelName("channel-1")]
public class ChannelMessageModel
{
    public string Message { get; set; }
}