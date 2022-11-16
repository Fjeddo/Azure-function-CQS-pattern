using az_functions_cs_cqs_pattern.Code;
using az_functions_cs_cqs_pattern.Code.FakeDb;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
        services
            .AddSingleton<IQueryExecuter, QueryExecuter>()
            .AddSingleton<ICommandHandler, CommandHandler>()
            .AddScoped<UpdateUserProcess>()
            .AddScoped<IUserStorage, FakeUserStorage>())
    .Build();

host.Run();











































/*
(ctx, builder) =>
    {
        builder.UseMiddleware(async (context, next) =>
        {
            var logger = context.InstanceServices.GetService<ILogger<Program>>();
            logger.LogInformation("Hey from middleware!");
            await next();
            logger.LogInformation("Goodbye from middleware!");
        });
    }
 */



/*
 
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

            logger.LogInformation("START0 ------------>");
            await next();
        });

        builder.UseMiddleware(async (context, next) =>
        {
            var logger = context.InstanceServices.GetService<ILogger<Program>>();

            logger.LogInformation("START1 ------------>");
            await next();
        });
    }


 */ 