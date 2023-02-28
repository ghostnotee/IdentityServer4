using IdentityServer4.Models;

namespace IdentityServer.AuthServer;

public static class Config
{
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>()
        {
            new ApiResource("resource_api1")
            {
                Scopes = { "api1.read", "api1.write", "api1.update" }
            },
            new ApiResource("resource_api2")
            {
                Scopes= { "api2.read", "api2.write", "api2.update" }
            }
        };
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new List<ApiScope>()
        {
            new ApiScope("api1.read","Reading permission for Api 1 "),
            new ApiScope("api1.write","Writing permission for Api 1 "),
            new ApiScope("api1.update","Update authority for API 1 "),
            new ApiScope("api2.read","Reading permission for Api 2 "),
            new ApiScope("api2.write","Writing permission for Api 2 "),
            new ApiScope("api2.update","Update authority for API 2 "),
        };
    }

    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>()
        {
            new Client()
            {
                ClientId = "Client1",
                ClientName="Client App 1",
                ClientSecrets = new []{new Secret("testsecret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "api1.read" }
            },
            new Client()
            {
                ClientId = "Client2",
                ClientName="Client App 2",
                ClientSecrets = new []{new Secret("testsecret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "api1.read", "api2.read", "api2.write", "api2.update" }
            }
        };
    }
}