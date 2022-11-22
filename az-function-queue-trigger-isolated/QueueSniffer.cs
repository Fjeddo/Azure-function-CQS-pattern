using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace az_function_queue_trigger_isolated;

public class QueueSniffer
{
    private readonly ILogger _logger;

    public QueueSniffer(ILoggerFactory loggerFactory) 
        => _logger = loggerFactory.CreateLogger<QueueSniffer>();

    [Function("QueueSniffer")]
    public void Run([QueueTrigger("notify", Connection = "AzureWebJobsStorage")] string myQueueItem) 
        => _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
}