using System.Net;
using az_function_cs_cqs_pattern_isolated;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;

public class AuthMiddleware : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        if (await context.GetHttpRequestDataAsync() is { } requestData)
        {
            var headers = requestData.Headers;
            if (headers.TryGetValues("auth", out var authValues))
            {
                if (authValues.SingleOrDefault() is { } and "let-me-in")
                {
                    await next(context);
                    return;
                }
            }
            
            var httpResponseData = await requestData.CreateStatusCodeResult(HttpStatusCode.Forbidden);

            context.GetInvocationResult().Value = httpResponseData;
            return;
        }
        else
        {
            await next(context);
        }
    }
}

//(context, builder) => builder.UseMiddleware<AuthMiddleware>()
