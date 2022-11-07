using System.Threading.Tasks;

namespace az_functions_cs_cqs_pattern.Code.Commands
{
    public interface ICommand<T>
    {
        Task<T> Execute(T domainModel);
    }
}