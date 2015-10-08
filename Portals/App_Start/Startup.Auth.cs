using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Configuration;
using Owin.Security.Providers.LinkedIn;
using Microsoft.Owin.Security.Google;


namespace Portals
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
              {
                 ClientId = ConfigurationManager.AppSettings["GoogleKey"],
                 ClientSecret = ConfigurationManager.AppSettings["GoogleSecret"]
              });

            app.UseLinkedInAuthentication(
                clientId: ConfigurationManager.AppSettings["LinkedInAPIKey"].ToString(),
                clientSecret: ConfigurationManager.AppSettings["LinkedInAPISecret"].ToString());

            //var linkedInOptions = new LinkedInAuthenticationOptions();

            //linkedInOptions.ClientId = ConfigurationManager.AppSettings["LinkedInAPIKey"].ToString();
            //linkedInOptions.ClientSecret = ConfigurationManager.AppSettings["LinkedInAPISecret"].ToString();

            //linkedInOptions.Scope.Add("r_fullprofile");

            //linkedInOptions.Provider = new LinkedInAuthenticationProvider()
            //{
            //    OnAuthenticated = async context =>
            //    {
            //        context.Identity.AddClaim(new System.Security.Claims.Claim("LinkedIn_AccessToken", context.AccessToken));
            //    }
            //};

            //linkedInOptions.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;

            //app.UseLinkedInAuthentication(linkedInOptions);

        }
    }
}