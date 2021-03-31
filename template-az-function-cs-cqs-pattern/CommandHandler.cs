using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using template_az_function_cs_cqs_pattern.Commands;

namespace template_az_function_cs_cqs_pattern
{
    public class CommandHandler : ICommandHandler
    {
        private readonly ILogger<ICommandHandler> _log;

        public CommandHandler(ILogger<ICommandHandler> log)
        {
            _log = log;
        }
        
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