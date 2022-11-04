using System.Threading.Tasks;
using az_func_cs_cqs_pattern.Code.Queries;

namespace az_func_cs_cqs_pattern.Code
{
    public interface IQueryExecuter
    {
        Task<(bool success, TDomainModel result, int status)> Execute<TDomainModel>(IQuery<TDomainModel> query);
    }
}