using System.Threading.Tasks;

namespace az_func_cs_cqs_pattern.Code.Commands
{
    public interface ICommand<T>
    {
        Task<T> Execute(T domainModel);
    }
}