using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conductor.IdentityServer
{
    public static class Ids4Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            var apiList = new List<ApiResource>();
            apiList.Add(new ApiResource("MyApi1"));
            apiList.Add(new ApiResource("MyApi2"));
            return apiList;
        }

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
          new List<ApiScope>
          {
                new ApiScope("MyApi1")
              , new ApiScope("MyApi2")
              , new ApiScope("MyApiPwd1")
              , new ApiScope("MyApiPwd2")
          };

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "MyApi1", "MyApi2" }
                },
                new Client
                {
                    ClientId = "client2",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "MyApiPwd1", "MyApiPwd2" }
                },
                new Client
                {
                    ClientId = "clientMvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    RedirectUris = { "https://localhost:7001/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:7001/signout-callback-oidc" },
                    SlidingRefreshTokenLifetime = 300,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                new Client{
                    ClientId ="clientVue",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser=true,
                      // where to redirect to after login
                    RedirectUris = { "http://localhost:9528/callback" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:9528" },
                    AllowedCorsOrigins={ "http://localhost:9528" },
                    AccessTokenLifetime=3600,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };

        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser()
                {
                     SubjectId = "1",
                     Username = "edwin",
                     Password = "123456"
                }
            };
        }

    }
}
