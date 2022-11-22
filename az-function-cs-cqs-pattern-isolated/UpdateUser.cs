using System.Net;
using az_functions_cs_cqs_pattern.Code;
using az_functions_cs_cqs_pattern.Code.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace az_function_cs_cqs_pattern_isolated;

public class UpdateUser
{
    private readonly UpdateUserProcess _updateUserProcess;

    public UpdateUser(UpdateUserProcess updateUserProcess) => _updateUserProcess = updateUserProcess;

    [Function("UpdateUser")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "user")] HttpRequestData req)
    {
        var updateUserRequest = await req.ReadFromJsonAsync<UpdateUserRequest>();

        var (success, model, status) = await _updateUserProcess.Run(updateUserRequest);

        if (success)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new UserDto(model));

            return response;
        }
        else
        {
            var response = req.CreateResponse((HttpStatusCode)status);
            return response;
        }
    }
}