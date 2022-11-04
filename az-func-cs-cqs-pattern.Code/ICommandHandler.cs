using System.Threading.Tasks;
using az_func_cs_cqs_pattern.Code.Commands;

namespace az_func_cs_cqs_pattern.Code
{
    public interface ICommandHandler
    {
        Task<TDomainModel> Handle<TDomainModel>(ICommand<TDomainModel> command, TDomainModel state);
    }
}