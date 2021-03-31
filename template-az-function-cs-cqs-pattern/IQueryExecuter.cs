using System.Threading.Tasks;
using template_az_function_cs_cqs_pattern.Queries;

namespace template_az_function_cs_cqs_pattern
{
    public interface IQueryExecuter
    {
        Task<(bool success, TDomainModel result, int status)> Execute<TDomainModel>(IQuery<TDomainModel> query);
    }
}