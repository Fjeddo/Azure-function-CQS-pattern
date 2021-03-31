using System.Threading.Tasks;
using template_az_function_cs_cqs_pattern.Commands;

namespace template_az_function_cs_cqs_pattern
{
    public interface ICommandHandler
    {
        Task<TDomainModel> Handle<TDomainModel>(ICommand<TDomainModel> command, TDomainModel state);
    }
}