using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using template_az_function_cs_cqs_pattern.Commands;
using template_az_function_cs_cqs_pattern.Domain;
using template_az_function_cs_cqs_pattern.Models;
using template_az_function_cs_cqs_pattern.Queries;

namespace template_az_function_cs_cqs_pattern
{
    public class UpdateUserProcess : IProcess<UpdateUserRequest, User>
    {
        private readonly IQueryExecuter _queryExecuter;
        private readonly ICommandHandler _commandHandler;
        private readonly ILogger _log;

        public UpdateUserProcess(IQueryExecuter queryExecuter, ICommandHandler commandHandler, ILogger<UpdateUserProcess> log)
        {
            _queryExecuter = queryExecuter;
            _commandHandler = commandHandler;
            _log = log;
        }

        public async Task<(bool success, User model, int status)> Run(UpdateUserRequest request)
        {
            _log.LogInformation($"Running process {GetType().Name}");

            try
            {
                var getUserQuery = new GetUserBySsnQuery(request.Ssn);

                var (success, updatedUser, status) = await _queryExecuter.Execute(getUserQuery);
                if (!success)
                {
                    _log.LogInformation($"Failed getting user {request.Ssn}");
                    return (false, default, status);
                }
                
                var updateNameCommand = new UpdateNameCommand(request.Name);
                var updateWorkCommand = new UpdateWorkCommand(request.Work);

                updatedUser = await _commandHandler.Handle(updateNameCommand, updatedUser);
                updatedUser = await _commandHandler.Handle(updateWorkCommand, updatedUser);

                return (true, updatedUser, 0);
            }
            catch (Exception)
            {
                _log.LogInformation($"Failed process {GetType().Name}");
                return (false, default, 555);
            }
            finally
            {
                _log.LogInformation($"Run process {GetType().Name}");
            }
        }
    }
}