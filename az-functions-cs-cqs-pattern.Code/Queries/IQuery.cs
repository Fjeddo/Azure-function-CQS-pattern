using System.Threading.Tasks;

namespace az_functions_cs_cqs_pattern.Code.Queries
{
    public interface IQuery<TDomainModel>
    {
        Task<(bool success, TDomainModel result, int status)> Execute();
    }
}