// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServerAspNetIdentity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource()
                {
                    Name = "custom",
                    DisplayName = "custom resource",
                    Description = "get custom claims",
                    UserClaims = new string[]{"custom-claim"}
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1"),
                new ApiScope("api2")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                    {
                        ClientId = "client",

                        // no interactive user, use the clientid/secret for authentication
                        AllowedGrantTypes = GrantTypes.ClientCredentials,

                        // secret for authentication
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },

                        // scopes that client has access to
                        AllowedScopes = { "api1" }
                    },
                new Client
                    {
                        ClientId = "mvc",
                        ClientSecrets = { new Secret("secret".Sha256()) },

                        AllowedGrantTypes = GrantTypes.Code,

                        // where to redirect to after login
                        RedirectUris = { "https://localhost:5002/signin-oidc" },

                        // where to redirect to after logout
                        PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                        AllowOfflineAccess = true,

                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "custom",
                            "api1"
                        }
                    },
                 new Client
                    {
                        ClientId = "react",

                        RequireClientSecret = false,
                        AllowedGrantTypes = GrantTypes.Code,

                        // where to redirect to after login
                        RedirectUris = { "http://localhost:3000/authentication/callback" },

                        // where to redirect to after logout
                        PostLogoutRedirectUris = { "http://localhost:3000/signout-callback-oidc" },

                        AllowOfflineAccess = true,

                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "custom",
                            "api1"
                        }
                    }
            };

        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "alice",
                        Password = "alice",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonConvert.SerializeObject(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim("custom-claim"," my custom claim")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "bob",
                        Password = "bob",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Address, JsonConvert.SerializeObject(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
    }
}