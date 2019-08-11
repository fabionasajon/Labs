using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace MVC_Angular_Bootstrap.UI
{
    public class ServiceAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            // Validate arguments
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }

            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }

            // Check the user name and password
            if (userName != "test" || password != "test")
            {
                throw new SecurityTokenException("Unknown username or password.");
            }
        }
    }
}