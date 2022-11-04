using System.Net;
using az_func_cs_cqs_pattern.Code;
using az_func_cs_cqs_pattern.Code.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace az_func_isolated_cs_cqs_pattern;

public class UpdateUser
{
    private readonly ILogger _logger;
    private readonly UpdateUserProcess _updateUserProcess;

    public UpdateUser(UpdateUserProcess updateUserProcess, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<UpdateUser>();
        _updateUserProcess = updateUserProcess;
    }

    [Function("Function1")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
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
}