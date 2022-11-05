using az_func_cs_cqs_pattern.Code;
using az_func_cs_cqs_pattern.Code.FakeDb;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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