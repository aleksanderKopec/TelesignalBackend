using Duende.IdentityServer.Models;
using Telesignal.Common.Config;

namespace Telesignal.IdentityServer.Config;

public static class ResourcesConfig
{
    readonly public static string
        MobileAppSecret = Environment.GetEnvironmentVariable(EnvironmentVariables.API_SECRET)!;

    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[] {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new[] {
            new ApiScope(IdentityScopes.ClientScope.ToString()),
            new ApiScope(IdentityScopes.ManagementScope.ToString()),
            new ApiScope(IdentityScopes.AdminScope.ToString())
        };

    public static IEnumerable<Client> Clients =>
        new[] {
            // Mobile application client
            new Client {
                ClientId = IdentityClients.MobileApplication.ToString(),
                ClientName = "Mobile application",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret(MobileAppSecret.Sha256()) },
                AllowedScopes = { IdentityScopes.ClientScope.ToString() }
            }
        };
}
