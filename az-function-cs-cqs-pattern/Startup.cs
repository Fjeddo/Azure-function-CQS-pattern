using az_func_cs_cqs_pattern.Code;
using az_func_cs_cqs_pattern.Code.FakeDb;
using az_function_cs_cqs_pattern;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(Startup))]

namespace az_function_cs_cqs_pattern
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddSingleton<IQueryExecuter, QueryExecuter>()
                .AddSingleton<ICommandHandler, CommandHandler>()
                .AddScoped<UpdateUserProcess>()
                .AddScoped<IUserStorage, FakeUserStorage>()
                .AddLogging(loggingBuilder => loggingBuilder.AddFilter(typeof(Startup).Namespace, LogLevel.Information));
        }
    }
}