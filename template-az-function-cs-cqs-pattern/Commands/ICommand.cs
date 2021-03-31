using System.Threading.Tasks;

namespace template_az_function_cs_cqs_pattern.Commands
{
    public interface ICommand<T>
    {
        Task<T> Execute(T domainModel);
    }
}