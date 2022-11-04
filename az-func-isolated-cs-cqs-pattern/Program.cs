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
