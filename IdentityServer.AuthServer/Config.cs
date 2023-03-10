using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer.AuthServer;

public static class Config
{
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>()
        {
            new ApiResource("resource_api1")
            {
                Scopes = { "api1.read", "api1.write", "api1.update" },
                ApiSecrets = new[]{new Secret("api1secret".Sha256())}
            },
            new ApiResource("resource_api2")
            {
                Scopes= { "api2.read", "api2.write", "api2.update" },
                ApiSecrets = new[]{new Secret("api2secret".Sha256())}
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
            },
            new Client()
            {
                ClientId = "Client1-Mvc",
                ClientName="Client App 1 Mvc",
                RequirePkce = false,
                ClientSecrets = new []{new Secret("testsecret".Sha256())},
                AllowedGrantTypes = GrantTypes.Hybrid,
                RedirectUris = new List<string>{ "https://localhost:7133/signin-oidc" },
                AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile,"api1.read"}
            }
        };
    }

    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
    }

    public static List<TestUser> GetTestUsers()
    {
        return new List<TestUser>()
        {
            new TestUser(){
                SubjectId = "1",
                Username = "ghostNoté",
                Password = "password",
                Claims = new List<Claim>()
                    {
                        new Claim("given_name","Ghost"),
                        new Claim("family_name","Note")
                    }
            },
            new TestUser()
            {
                SubjectId = "2",
                Username = "marshall",
                Password = "password",
                Claims = new List<Claim>()
                    {
                        new Claim("given_name","Marshall"),
                        new Claim("family_name","Gray")
                    }
            }
        };
    }
}