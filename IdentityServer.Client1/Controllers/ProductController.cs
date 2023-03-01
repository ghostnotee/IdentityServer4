using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Client1.Controllers;

public class ProductController : Controller
{
    private readonly IConfiguration _configuration;

    public ProductController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient httpClient = new HttpClient();
        var discovery = await httpClient.GetDiscoveryDocumentAsync("https://localhost:7078");

        if (discovery.IsError)
        {
            // ToDo log etc.
        }

        ClientCredentialsTokenRequest request = new ClientCredentialsTokenRequest();
        request.ClientId = _configuration["Client:ClientId"];
        request.ClientSecret = _configuration.GetSection("Client").GetSection("ClientSecret").Value;
        request.Address = discovery.TokenEndpoint;
        var token = await httpClient.RequestClientCredentialsTokenAsync(request);

        if (token.IsError)
        {
            // ToDo log etc.
        }

        // https://localhost:7298

        httpClient.SetBearerToken(token.AccessToken);
        var response = await httpClient.GetAsync("https://localhost:7298/api/product/getproduct");

        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsStringAsync();
        }
        else
        {

        }

        return View();
    }
}
