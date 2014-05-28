using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.AccessControl2.SDK;

namespace SecurityModule
{
    class SWTModule : IHttpModule
    {
        //USE CONFIGURATION FILE, WEB.CONFIG, TO MANAGE THIS DATA
        //string serviceNamespace = "sdbacs";
        //string acsHostName = "accesscontrol.windows.net";
        //string trustedTokenPolicyKey = "LdoRf3hzXKPl4CAmCpyJo1PL4otezG9zM5mH6JXEg1Y=";
        //string trustedAudience = "http://localhost:40000";


        static string serviceNamespace = ConfigurationManager.AppSettings["serviceNamespace"];
        static string acsHostName = ConfigurationManager.AppSettings["acsHostUrl"];
        static string trustedAudience = ConfigurationManager.AppSettings["realm"];
        string trustedTokenPolicyKey = ConfigurationManager.AppSettings["trustedTokenPolicyKey"];
      

        void IHttpModule.Dispose()
        {

        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            
            //HANDLE SWT TOKEN VALIDATION
            // get the authorization header
            string headerValue = HttpContext.Current.Request.Headers.Get("Authorization");

            // check that a value is there
            if (string.IsNullOrEmpty(headerValue))
            {
                throw new ApplicationException("unauthorized");
            }

            // check that it starts with 'WRAP'
            if (!headerValue.StartsWith("WRAP "))
            {
                throw new ApplicationException("unauthorized");
            }

            string[] nameValuePair = headerValue.Substring("WRAP ".Length).Split(new char[] { '=' }, 2);

            if (nameValuePair.Length != 2 ||
                nameValuePair[0] != "access_token" ||
                !nameValuePair[1].StartsWith("\"") ||
                !nameValuePair[1].EndsWith("\""))
            {
                throw new ApplicationException("unauthorized");
            }

            // trim off the leading and trailing double-quotes
            string token = nameValuePair[1].Substring(1, nameValuePair[1].Length - 2);

            // create a token validator
            TokenValidator validator = new TokenValidator(
                acsHostName,
                 serviceNamespace,
                trustedAudience,
                 trustedTokenPolicyKey);

            // validate the token
            if (!validator.Validate(token))
            {
                throw new ApplicationException("unauthorized");
            }

            Dictionary<string, string> tokenValues = validator.GetNameValues(token);



            var app = (System.Web.HttpApplication)sender;

            //Pass Token Values in the HTTP context
             if (app.Context.Items["ACSToken"] == null)
            {
                app.Context.Items.Add("ACSToken", tokenValues);

            }
            else
            {
                app.Context.Items["ACSToken"] = tokenValues;
            }


        }
    }
}