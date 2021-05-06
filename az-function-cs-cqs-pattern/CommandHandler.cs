using System.Threading.Tasks;
using az_function_cs_cqs_pattern.Commands;
using Microsoft.Extensions.Logging;

namespace az_function_cs_cqs_pattern
{
    public class CommandHandler : ICommandHandler
    {
        private readonly ILogger<ICommandHandler> _log;

        public CommandHandler(ILogger<ICommandHandler> log) => _log = log;

        public async Task<TDomainModel> Handle<TDomainModel>(ICommand<TDomainModel> command, TDomainModel state)
        {
            var commandType = command.GetType();
                
            _log.LogInformation($"Handling {commandType.Name}");
            var result = await command.Execute(state);
            _log.LogInformation($"Handled {commandType.Name}");
            
            return result;
        }
    }
}