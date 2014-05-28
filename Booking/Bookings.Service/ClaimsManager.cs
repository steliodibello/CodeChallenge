using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Bookings.Models;

namespace Bookings.Service
{
   public class ClaimsManager
    {
        public  static UserContext GetUserFromContext()
        {
            var user = new UserContext();

            if (HttpContext.Current.Items["ACSToken"] !=null)
            {
                var claims = (Dictionary<string, string>)HttpContext.Current.Items["ACSToken"];
                user.UserName = claims["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
                //Add Organization claim from the identity provider or eventually retrieve it from User Database..
                user.Organization = claims["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
            }

            return user;
        }
    }
}
