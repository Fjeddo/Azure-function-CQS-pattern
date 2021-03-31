using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using template_az_function_cs_cqs_pattern.Queries;

namespace template_az_function_cs_cqs_pattern
{
    public class QueryExecuter : IQueryExecuter
    {
        private readonly ILogger<IQueryExecuter> _log;

        public QueryExecuter(ILogger<IQueryExecuter> log)
        {
            _log = log;
        }

        public async Task<(bool success, TDomainModel result, int status)> Execute<TDomainModel>(IQuery<TDomainModel> query)
        {
            var queryType = query.GetType();

            _log.LogInformation($"Executing {queryType.Name}");
            var retVal = await query.Execute();
            _log.LogInformation($"Executed {queryType.Name}");

            return retVal;
        }
    }
}