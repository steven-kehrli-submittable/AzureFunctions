using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace AzureFunctions.HelloWorld7;

/// <summary>
/// Based on https://stackoverflow.com/questions/67937686/testing-an-azure-function-in-net-5
/// </summary>
public class TestHttpResponseData : HttpResponseData
{
    public TestHttpResponseData(
        FunctionContext functionContext) : base(functionContext)
    {
    }

    public override Stream Body { get; set; } = new MemoryStream();

    public override HttpCookies Cookies { get; } = new TestHttpCookies();

    public override HttpHeadersCollection Headers { get; set; } = new();

    public override HttpStatusCode StatusCode { get; set; }

    public static T ReadBody<T>(
        HttpResponseData httpResponseData)
    {
        // reset the memory stream to the beginning
        httpResponseData.Body.Seek(0, SeekOrigin.Begin);

        return StreamHelper.Deserialize<T>(httpResponseData.Body);
    }

    private class TestHttpCookies : HttpCookies
    {
        public override void Append(
            string name,
            string value)
        {
            throw new NotImplementedException();
        }

        public override void Append(
            IHttpCookie cookie)
        {
            throw new NotImplementedException();
        }

        public override IHttpCookie CreateNew()
        {
            throw new NotImplementedException();
        }
    }
}
