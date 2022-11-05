using System.Net;
using az_func_cs_cqs_pattern.Code;
using az_func_cs_cqs_pattern.Code.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace az_func_isolated_cs_cqs_pattern_NET6;

public class UpdateUser
{
    private readonly UpdateUserProcess _updateUserProcess;

    public UpdateUser(UpdateUserProcess updateUserProcess)
    {
        _updateUserProcess = updateUserProcess;
    }

    [Function("UpdateUser")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, methods: "post", Route = "user")] HttpRequestData req)
    {
        var updateUserRequest = await req.ReadFromJsonAsync<UpdateUserRequest>();

        var (success, model, status) = await _updateUserProcess.Run(updateUserRequest);

        if (success)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(model);

            return response;
        }
        else
        {
            var response = req.CreateResponse((HttpStatusCode)status);
            return response;
        }
    }

    [Function("UpdateUserExt")]
    public async Task<HttpResponseData> RunExt([HttpTrigger(AuthorizationLevel.Function, methods: "post", Route = "userExt")] HttpRequestData req)
    {
        var updateUserRequest = await req.ReadFromJsonAsync<UpdateUserRequest>();

        var (success, model, status) = await _updateUserProcess.Run(updateUserRequest);

        return success
            ? await req.CreateOkObjectResult(model)
            : await req.CreateStatusCodeResult(status);
    }
}