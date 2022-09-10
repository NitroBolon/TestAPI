using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { 
                new ApiScope(name: "users.api", displayName: "UsersAPI"),
                new ApiScope(name: "tasks.api", displayName: "TasksAPI"),
            };

    public static IEnumerable<Client> Clients =>
        new Client[]
        { 
            new Client
            {
                ClientId = "test.usersapi",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("apitestusers".Sha256())
                },
                AllowedScopes = { "users.api" }
            },
            new Client
            {
                ClientId = "test.superadmin",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("apisupertest".Sha256())
                },
                AllowedScopes = { "tasks.api", "users.api" }
            },
            new Client
            {
                ClientId = "test.usersapi.swagger",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("apitestusers".Sha256())
                },
                AllowedScopes = { "users.api" }
            }
        };
}