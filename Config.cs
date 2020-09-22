using IdentityServer4.Models;
using System.Collections.Generic;
namespace sso_api
{
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
                new ApiScope(name: "read",   displayName: "Read your data."),
                new ApiScope(name: "write",  displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data.")
            };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                {
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientId = "xpto_app",
                    ClientSecrets = { new Secret("xpto_segredo".Sha256()) },
                    AllowedScopes = { "openid", "profile", "read", "write", "delete" },
                    ClientClaimsPrefix = ""
                }
            };
    }
}