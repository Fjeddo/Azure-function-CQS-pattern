using az_function_cs_cqs_pattern;
using az_functions_cs_cqs_pattern.Code;
using az_functions_cs_cqs_pattern.Code.FakeDb;
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