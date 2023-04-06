using System.Net;
using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AzureFunctions.HelloWorld7;

/// <summary>
/// These tests will validate HTTP requests against the Azure Function
/// This is based on https://devkimchi.com/2021/08/26/azure-functions-integration-testing/
/// Prerequisite is the Azure Function is running locally
/// From the command line and HelloWorld (Azure Function) project, run: func start --csharp
/// This will start a local instance of the Azure Function: http://localhost:7071/api/HelloWorld7
/// </summary>
public class IntegrationTests
{
    private readonly HttpClient _httpClient = new();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [Explicit]
    [Category("IntegrationTests")]
    public async Task TestGet()
    {
        var httpResponse = await _httpClient.GetAsync("http://localhost:7071/api/HelloWorld7");

        Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var responseJson = await httpResponse.Content.ReadAsStringAsync();

        var expectedJsonObj = new
        {
            path = "/api/HelloWorld7",
            method = "GET"
        };

        var expectedJson = JsonConvert.SerializeObject(expectedJsonObj);

        Assert.That(responseJson, Is.EqualTo(expectedJson));
    }

    [Test]
    [Explicit]
    [Category("IntegrationTests")]
    public async Task TestPost()
    {
        var httpContent = new StringContent(string.Empty, Encoding.UTF8, MediaTypeNames.Application.Json);

        var httpResponse = await _httpClient.PostAsync("http://localhost:7071/api/HelloWorld7", httpContent);

        Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
}
