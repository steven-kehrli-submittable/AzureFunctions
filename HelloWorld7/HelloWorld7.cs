using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctions.HelloWorld7;

public class HelloWorld7
{
    private readonly ILogger _logger;

    public HelloWorld7(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<HelloWorld7>();
    }

    [Function("HelloWorld7")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
        HttpRequestData req)
    {
        var json = new
        {
            path = req.Url.AbsolutePath,
            method = req.Method
        };

        _logger.LogInformation(json.ToString());

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(json);

        return response;
    }
}
