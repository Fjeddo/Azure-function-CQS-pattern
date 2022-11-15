using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

public class ResultNotification
{
    public HttpResponseData Response { get; init; }

    [QueueOutput("notify")]
    public string Ssn { get; init; }
}
















































//public record ResultNotificationR(HttpResponseData Response, [property: QueueOutput("notify")] string? Ssn = default);
