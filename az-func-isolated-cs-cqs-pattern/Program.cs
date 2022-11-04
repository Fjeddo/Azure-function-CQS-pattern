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



--------------


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




*/
