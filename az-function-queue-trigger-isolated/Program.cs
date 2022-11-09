using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults((context, builder) =>
    {
        builder.UseMiddleware(async (functionContext, next) =>
        {
            var logger = functionContext.InstanceServices.GetService<ILogger<Program>>();
            logger.LogInformation("Queue message arrived");
            await next();
        });
    })
    .Build();

host.Run();
