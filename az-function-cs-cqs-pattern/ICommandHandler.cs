using System.Threading.Tasks;
using az_function_cs_cqs_pattern.Commands;

namespace az_function_cs_cqs_pattern
{
    public interface ICommandHandler
    {
        Task<TDomainModel> Handle<TDomainModel>(ICommand<TDomainModel> command, TDomainModel state);
    }
}