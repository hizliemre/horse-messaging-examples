using Horse.Messaging.Client.Direct.Annotations;

namespace Devnot.Message.Receiver;

[DirectContentType(1001)]
[DirectTarget(FindTargetBy.Type, "message-receiver")]
public class RequestMessage
{
    public int Number { get; set; }
}