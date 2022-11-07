using az_func_cs_cqs_pattern.Code.FakeDb;
using az_func_cs_cqs_pattern.Code;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IQueryExecuter, QueryExecuter>()
            .AddSingleton<ICommandHandler, CommandHandler>()
            .AddScoped<UpdateUserProcess>()
            .AddScoped<IUserStorage, FakeUserStorage>();
    })
    .Build();

host.Run();




































/*
(context, builder) => 
{
        builder.UseWhen(
            _ => DateTimeOffset.Now.Second % 2 == 0,
            async (context, _) =>
            {
                if (await context.GetHttpRequestDataAsync() is {} req)
                {
                    context.GetInvocationResult().Value = req.CreateResponse(HttpStatusCode.UnavailableForLegalReasons);
                }
            }
        );
}

--------------

(context, builder) => 
{
        builder.UseMiddleware(async (context, next) =>
        {
            await next();

            var logger = context.InstanceServices.GetService<ILogger<Program>>();
            logger.LogInformation("----------------> END");
        });

        builder.UseMiddleware(async (context, next) =>
        {
            var logger = context.InstanceServices.GetService<ILogger<Program>>();

            logger.LogInformation("START1 ------------>");
            await next();
        });

        builder.UseMiddleware(async (context, next) =>
        {
            var logger = context.InstanceServices.GetService<ILogger<Program>>();

            logger.LogInformation("START2 ------------>");
            await next();
        });
}

-----------


(context, builder) => builder.UseMiddleWare<AuthMiddleware>()


public class AuthMiddleware : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        if (await context.GetHttpRequestDataAsync() is { } requestData)
        {
            var headers = requestData.Headers;
            if (headers.TryGetValues("auth", out var authValues))
            {
                if (authValues.SingleOrDefault() is { } and "let-me-in")
                {
                    await next(context);
                    return;
                }
            }

            context.GetInvocationResult().Value = requestData.CreateResponse(HttpStatusCode.Forbidden);
            return;
        }
        else
        {
            await next(context);
        }
    }
}

*/