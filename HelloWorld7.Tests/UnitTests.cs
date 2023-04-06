using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace AzureFunctions.HelloWorld7;

public class UnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [Explicit]
    [Category("UnitTests")]
    public async Task TestGet()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .Build();

        var functionContext = new Mock<FunctionContext>();
        functionContext.SetupProperty(c => c.InstanceServices, host.Services);

        var httpRequestData = new TestHttpRequestData(
            functionContext.Object,
            "GET",
            new Uri("http://localhost:7071/api/HelloWorld7"));

        var function = new HelloWorld7(NullLoggerFactory.Instance);
        var httpResponseData = await function.Run(httpRequestData);

        Assert.That(httpResponseData.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // the api is creating a dynamic json object
        // so we don't have a class we can deserialize
        var json = TestHttpResponseData.ReadBody<dynamic>(httpResponseData);

        // since this is a dynamic object, path and method will be Newtonsoft JValue
        // convert both to string
        Assert.That(json.path.ToString(), Is.EqualTo("/api/HelloWorld7"));
        Assert.That(json.method.ToString(), Is.EqualTo("GET"));
    }
}
