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
                new ApiScope(name: "tenants.api", displayName: "TenantsAPI"),
                new ApiScope(name: "licenses.api", displayName: "LicensesAPI"),
            };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("users.api")
            {
                Scopes = { "users.api" },
                ApiSecrets =
                {
                    new Secret("apitestusers".Sha256())
                }
            },
            new ApiResource("tasks.api")
            {
                Scopes = { "tasks.api" },
                ApiSecrets =
                {
                    new Secret("apitesttasks".Sha256())
                }
            },
            new ApiResource("tenants.api")
            {
                Scopes = { "tenants.api" },
                ApiSecrets =
                {
                    new Secret("apitesttenants".Sha256())
                }
            },
            new ApiResource("licenses.api")
            {
                Scopes = { "licenses.api" },
                ApiSecrets =
                {
                    new Secret("apitestlicenses".Sha256())
                }
            }
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
                AllowedScopes = { "tasks.api", "users.api", "tenants.api", "licenses.api" }
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