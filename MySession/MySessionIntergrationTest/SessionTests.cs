using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using MySession;

namespace MySessionIntergrationTest;

public class SessionTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _factory;
    public SessionTests(WebApplicationFactory<Program> factory)
    {
        this._factory = factory.CreateClient();
    }
    [Fact]
    public async Task Call_TestGetSession_Returns_Ok_Async()
    {
        var response = await _factory.GetAsync($"/Test/TestGetSession");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Call_Set_And_Get_SessionValueAsync_Returns_Ok_Async()
    {
        string randValue = Guid.NewGuid().ToString();
        await _factory.GetAsync($"/Test/SetSessionValue?key=TEST-KEY&value={randValue}");
        var response = await _factory.GetAsync($"/Test/GetSessionValue?key=TEST-KEY");
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(randValue, responseString);
    }
}