using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

public record ResultNotificationR(HttpResponseData Response, [property: QueueOutput("notify")] string? Ssn = default);