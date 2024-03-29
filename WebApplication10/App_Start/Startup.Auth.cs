﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using WebApplication10.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication10
{

    public partial class Startup {

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301883
        public void ConfigureAuth(IAppBuilder app)
        {

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            var extranet_url = new OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "extranet_sunchemical ",
                ClientId = "bdbdbdbdbdbdbdb-c63f-476a-9bb0-0281a6d499b",
                ClientSecret = "b46cb48f-c83b-4101-b907-bf040bb994b",
                RedirectUri = "http://extranet_sunchemical.com/",
                ResponseType = "code id_token",
                SaveTokens = true,
                //UseTokenLifetime=true,
                PostLogoutRedirectUri = "http://extranet_sunchemical.com/",
                RedeemCode = true,
                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name"
                },
                Authority = "https://idp.eu-staging.safenetid.com/auth/realms/5M6NSWEHFK-STA"
               
            };

            var internetconfig = new OpenIdConnectAuthenticationOptions
            {
                AuthenticationType = "sunchemical",
                ClientId = "abababababababa",
                ClientSecret = "abavavavavavavavava",
                RedirectUri = "http://sunchemical.com/",
                ResponseType = "code id_token",
                SaveTokens = true,
                //UseTokenLifetime=true,
                PostLogoutRedirectUri = "http://sunchemical.com/",
                RedeemCode = true,
                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name"
                },
                Authority = "https://idp.eu-staging.safenetid.com/auth/realms/8AFDSD3FK-STA"
                
            };

            
            app.UseOpenIdConnectAuthentication(extranet_url);
            app.UseOpenIdConnectAuthentication(internetconfig);


            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                delegate (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                        System.Security.Cryptography.X509Certificates.X509Chain chain,
                                        System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true; // **** Always accept
                };


            //// Configure the db context, user manager and signin manager to use a single instance per request
            //app.CreatePerOwinContext(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            //// Enable the application to use a cookie to store information for the signed in user
            //// and to use a cookie to temporarily store information about a user logging in with a third party login provider
            //// Configure the sign in cookie
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login"),
            //    Provider = new CookieAuthenticationProvider
            //    {
            //        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
            //            validateInterval: TimeSpan.FromMinutes(30),
            //            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
            //    }
            //});
            //// Use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //// Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            //app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            //// Enables the application to remember the second login verification factor such as phone or email.
            //// Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            //// This is similar to the RememberMe option when you log in.
            //app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            //// Uncomment the following lines to enable logging in with third party login providers
            ////app.UseMicrosoftAccountAuthentication(
            ////    clientId: "",
            ////    clientSecret: "");

            ////app.UseTwitterAuthentication(
            ////   consumerKey: "",
            ////   consumerSecret: "");

            ////app.UseFacebookAuthentication(
            ////   appId: "",
            ////   appSecret: "");

            ////app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            ////{
            ////    ClientId = "",
            ////    ClientSecret = ""
            ////});
        }
    }
}
