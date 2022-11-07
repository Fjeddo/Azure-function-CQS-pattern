using System.Threading.Tasks;
using az_functions_cs_cqs_pattern.Code.Queries;
using Microsoft.Extensions.Logging;

namespace az_functions_cs_cqs_pattern.Code
{
    public class QueryExecuter : IQueryExecuter
    {
        private readonly ILogger<IQueryExecuter> _log;

        public QueryExecuter(ILogger<IQueryExecuter> log) => _log = log;

        public async Task<(bool success, TDomainModel result, int status)> Execute<TDomainModel>(IQuery<TDomainModel> query)
        {
            var queryType = query.GetType();

            _log.LogInformation($"Executing {queryType.Name}");
            var result = await query.Execute();
            _log.LogInformation($"Executed {queryType.Name}");

            return result
;
        }
    }
}