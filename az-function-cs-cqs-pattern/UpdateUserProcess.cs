using System;
using System.Threading.Tasks;
using az_function_cs_cqs_pattern.Commands;
using az_function_cs_cqs_pattern.Domain;
using az_function_cs_cqs_pattern.Models;
using az_function_cs_cqs_pattern.Queries;
using Microsoft.Extensions.Logging;

namespace az_function_cs_cqs_pattern
{
    public class UpdateUserProcess : IProcess<UpdateUserRequest, User>
    {
        private readonly IQueryExecuter _queryExecuter;
        private readonly ICommandHandler _commandHandler;
        private readonly IUserStorage _userStorage;
        private readonly ILogger _log;

        public UpdateUserProcess(IQueryExecuter queryExecuter, ICommandHandler commandHandler, IUserStorage userStorage, ILogger<UpdateUserProcess> log)
        {
            _queryExecuter = queryExecuter;
            _commandHandler = commandHandler;
            _userStorage = userStorage;

            _log = log;
        }

        public async Task<(bool success, User model, int status)> Run(UpdateUserRequest request)
        {
            _log.LogInformation($"Running process {GetType().Name}");

            try
            {
                var getUserQuery = new GetUserBySsnQuery(request.Ssn, _userStorage);

                var (success, updatedUser, status) = await _queryExecuter.Execute(getUserQuery);
                if (!success)
                {
                    _log.LogInformation($"Failed getting user {request.Ssn}");
                    
                    return (false, default, status);
                }
                
                var updateNameCommand = new UpdateNameCommand(request.Name);
                updatedUser = await _commandHandler.Handle(updateNameCommand, updatedUser);
                
                var updateWorkCommand = new UpdateWorkCommand(request.Work);
                updatedUser = await _commandHandler.Handle(updateWorkCommand, updatedUser);

                return (true, updatedUser, 0);
            }
            catch (Exception exception)
            {
                _log.LogError(exception, $"Failed process {GetType().Name}");
                
                return (false, default, 555);
            }
            finally
            {
                _log.LogInformation($"Ran process {GetType().Name}");
            }
        }
    }
}