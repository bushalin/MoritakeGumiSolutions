using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace MG.Auth
{
    public class Config
    {
        // the information resources that we are going to protect
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>()
            {
                // INFO: these scopes are reflected in ID Token
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                //new IdentityResource(name: "profile", claimTypes: new []{"name", "email", "firstname", "lastname", "gender"}),
                new IdentityResources.Email(),
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
                new IdentityResource
                {
                    Name = "mg.scope",
                    UserClaims =
                    {
                        "test_claim"
                    }
                }
            };

        // the apis that we are going to protect
        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("dokoApi")
                {
                    Name = "dokoApi",
                    DisplayName = "Moritake-gumi Doko Application Api",
                    // INFO: Defining these userclaims will reflect in access_token
                    UserClaims = new List<string>
                    {
                        "test_claim",
                        JwtClaimTypes.Role
                    }
                }
            };

        // clients that are going to connect to this server
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    // clientId and secrets of the client application
                    ClientId = "doko.ui",
                    ClientSecrets = {new Secret("doko_ui_secret".Sha256())},

                    // grant-type and consents.
                    // offline access is used for refresh token
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    AllowOfflineAccess = true,

                    // includes all the claims in the id token
                    //AlwaysIncludeUserClaimsInIdToken = true,

                    // redirectUri is a required field. this redirect uri is got by the openidmodel package
                    RedirectUris = {"https://localhost:44392/signin-oidc"},

                    // allowed scopes of this client
                    AllowedScopes =
                    {
                        "dokoApi",
                        "mg.scope",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                    }
                }
            };
    }
}