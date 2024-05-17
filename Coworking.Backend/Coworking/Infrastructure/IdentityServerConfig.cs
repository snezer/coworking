using Duende.IdentityServer.Models;
using IdentityModel;

namespace Coworking.Infrastructure
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource()
            {
                Name = "api1",
                DisplayName = "API1",
                Scopes = new[] { new ApiScope("api1").Name },
                UserClaims = new[] { JwtClaimTypes.Name, JwtClaimTypes.Role, JwtClaimTypes.Email, KnownClaims.ClaimType }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            yield return new Client()
            {
                ClientId = "vue.client",
                ClientSecrets = { new Secret("vue.secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = { "api1" },
                RequireClientSecret = false,
                //AccessTokenLifetime = 2 * 60,

                AllowOfflineAccess = true,
                RefreshTokenUsage = TokenUsage.OneTimeOnly,
                RefreshTokenExpiration = TokenExpiration.Sliding,
                UpdateAccessTokenClaimsOnRefresh = true,
            };
        }
    }
}
