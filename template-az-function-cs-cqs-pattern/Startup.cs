using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(template_az_function_cs_cqs_pattern.Startup))]

namespace template_az_function_cs_cqs_pattern
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddSingleton<IQueryExecuter, QueryExecuter>()
                .AddSingleton<ICommandHandler, CommandHandler>()
                .AddScoped<UpdateUserProcess>()
                .AddLogging(loggingBuilder => loggingBuilder.AddFilter(typeof(Startup).Namespace, LogLevel.Information));
        }
    }
}