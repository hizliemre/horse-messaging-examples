using Horse.Messaging.Client;
using Horse.Messaging.Client.Direct;
using Horse.Messaging.Protocol;

namespace Devnot.Message.Receiver;

public class MessageHandler : IHorseRequestHandler<RequestMessage, ResponseMessage>
{
    public async Task<ResponseMessage> Handle(RequestMessage request, HorseMessage rawMessage, HorseClient client)
    {
        await Console.Out.WriteLineAsync($"Message received! The number is: {request.Number}");
        if (request.Number % 2 != 0) throw new Exception("The number was odd");
        ResponseMessage response = new()
        {
            Square = request.Number * request.Number
        };
        return response;
    }

    public Task<ErrorResponse> OnError(Exception exception, RequestMessage request, HorseMessage rawMessage, HorseClient client)
    {
        ErrorResponse result = new()
        {
            Reason = exception.Message,
            ResultCode = HorseResultCode.Failed
        };
        return Task.FromResult(result);
    }
}