using System.Threading.Tasks;

namespace template_az_function_cs_cqs_pattern.Queries
{
    public interface IQuery<TDomainModel>
    {
        Task<(bool success, TDomainModel result, int status)> Execute();
    }
}