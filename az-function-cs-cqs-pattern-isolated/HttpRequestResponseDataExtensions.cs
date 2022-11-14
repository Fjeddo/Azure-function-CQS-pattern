using System.Net;
using Microsoft.Azure.Functions.Worker.Http;

namespace az_function_cs_cqs_pattern_isolated;

public static class HttpRequestResponseDataExtensions
{
    /// <returns>http status 200, instance of T in body</returns>
    public static async Task<HttpResponseData> CreateOkObjectResult<T>(this HttpRequestData req, T @object)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(@object);

        return response;
    }

    /// <returns>http status [httpStatusCode], empty body</returns>
    public static async Task<HttpResponseData> CreateStatusCodeResult(this HttpRequestData req, int httpStatusCode)
        => req.CreateResponse((HttpStatusCode) httpStatusCode);
}