using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using template_az_function_cs_cqs_pattern.Models;

namespace template_az_function_cs_cqs_pattern
{
    public class UpdateUser
    {
        private readonly UpdateUserProcess _updateUserProcess;

        public UpdateUser(UpdateUserProcess updateUserProcess) => _updateUserProcess = updateUserProcess;

        [FunctionName("UpdateUser")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "user")] UpdateUserRequest updateUserRequest, ILogger log)
        {
            var (success, model, status) = await _updateUserProcess.Run(updateUserRequest);

            return success
                ? new OkObjectResult(new UserDto(model))
                : new StatusCodeResult(status);
        }
    }
}
