using System.Threading.Tasks;
using az_function_cs_cqs_pattern.Queries;

namespace az_function_cs_cqs_pattern
{
    public interface IQueryExecuter
    {
        Task<(bool success, TDomainModel result, int status)> Execute<TDomainModel>(IQuery<TDomainModel> query);
    }
}