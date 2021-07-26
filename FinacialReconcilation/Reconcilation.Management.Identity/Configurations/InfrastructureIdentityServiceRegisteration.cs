using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Http;

namespace Reconcilation.Management.Identity.Configurations
{
    public static class InfrastructureIdentityServiceRegisteration
    {

        public static IServiceCollection AddInfrastructureServcies(this IServiceCollection services, IConfiguration configuration)
        {


                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
               .AddCookie()
               .AddOpenIdConnect("Auth0", options =>
               {
                   // Set the authority to your Auth0 domain
                   options.Authority = $"https://{configuration["Auth0:Domain"]}";

                   // Configure the Auth0 Client ID and Client Secret
                   options.ClientId = configuration["Auth0:ClientId"];
                   options.ClientSecret = configuration["Auth0:ClientSecret"];

                   // Set response type to code
                   options.ResponseType = OpenIdConnectResponseType.Code;

                   // Configure the scope
                   options.Scope.Clear();
                   options.Scope.Add("openid");

                   // Set the callback path, so Auth0 will call back to http://localhost:3000/callback
                   // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard
                   options.CallbackPath = new PathString("/callback");

                   // Configure the Claims Issuer to be Auth0
                   options.ClaimsIssuer = "Auth0";
               });

            return services;
        }
    }
}


