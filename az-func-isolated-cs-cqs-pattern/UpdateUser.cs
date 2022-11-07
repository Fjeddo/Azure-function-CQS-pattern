using System.Net;
using az_func_cs_cqs_pattern.Code;
using az_func_cs_cqs_pattern.Code.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace az_func_isolated_cs_cqs_pattern;

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







































    [Function("UpdateUserAndNotify")]
    public async Task<ResultNotification> RunNotify([HttpTrigger(AuthorizationLevel.Function, methods: "post", Route = "userNotify")] HttpRequestData req)
    {
        var updateUserRequest = await req.ReadFromJsonAsync<UpdateUserRequest>();

        var (success, model, status) = await _updateUserProcess.Run(updateUserRequest);

        return success
            ? new ResultNotification {Response = await req.CreateOkObjectResult(model), Ssn = updateUserRequest.Ssn}
            : new ResultNotification {Response = await req.CreateStatusCodeResult(status)};
    }

    public class ResultNotification
    {
        public HttpResponseData Response { get; init; }

        [QueueOutput("notify")]
        public string Ssn { get; init; }
    }



















    [Function("UpdateUserAndNotify2")]
    public async Task<ResultNotificationR> RunNotify2([HttpTrigger(AuthorizationLevel.Function, methods: "post", Route = "userNotify2")] HttpRequestData req)
    {
        var updateUserRequest = await req.ReadFromJsonAsync<UpdateUserRequest>();

        var (success, model, status) = await _updateUserProcess.Run(updateUserRequest);

        return success
            ? new ResultNotificationR(await req.CreateOkObjectResult(model), updateUserRequest.Ssn)
            : new ResultNotificationR(await req.CreateStatusCodeResult(status));
    }

    public record ResultNotificationR(HttpResponseData Response, [property: QueueOutput("notify")] string? Ssn = default);
}
