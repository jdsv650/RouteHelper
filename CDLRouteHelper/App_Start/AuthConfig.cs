using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using CDLRouteHelper.Models;
using WebMatrix.WebData;

namespace CDLRouteHelper
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "wV7pjJcAv1IBmwaP0nQxQ",
                consumerSecret: "CuH5OVWTSNZ8bXibw5ebG6qbkROr3vIAlg1rd1l3SEs");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "482938785137923",
                appSecret: "cef0ea1a11d9aa692a4095d5a488e6e3");

            //OAuthWebSecurity.RegisterGoogleClient();

            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Users", "UserId", "UserName", autoCreateTables: false);


        }
    }
}
