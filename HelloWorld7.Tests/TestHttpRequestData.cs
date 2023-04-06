using System.Security.Claims;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace AzureFunctions.HelloWorld7;

/// <summary>
/// Based on https://stackoverflow.com/questions/67937686/testing-an-azure-function-in-net-5
/// </summary>
public class TestHttpRequestData : HttpRequestData
{
    public TestHttpRequestData(
        FunctionContext functionContext,
        string method,
        Uri url,
        Stream? body = null) : base(functionContext)
    {
        Method = method;
        Url = url;
        Body = body ?? new MemoryStream();
    }

    public override IReadOnlyCollection<IHttpCookie> Cookies { get; } = new List<IHttpCookie>().AsReadOnly();

    public override Stream Body { get; } = new MemoryStream();

    public override HttpHeadersCollection Headers { get; } = new();

    public override IEnumerable<ClaimsIdentity> Identities { get; } = Enumerable.Empty<ClaimsIdentity>();

    public override string Method { get; }

    public override Uri Url { get; }

    public override HttpResponseData CreateResponse()
    {
        return new TestHttpResponseData(FunctionContext);
    }
}
