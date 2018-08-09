using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoesECommerce.Models
{
    public static class SessionHelper
    {
        private const string Username = "Username";
        private const string Role = "Role";
        private const string Administrator = "Admin";
        private const string DefaultRole = "Customer";

        public static bool IsCustomer()
        {
            if(HttpContext.Current.Session[Role].ToString() == DefaultRole)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Log User IN with default role
        /// </summary>
        /// <param name="username">The user to log in</param>
        public static void LogUserIn(string username)
        {
            LogUserIn(username, DefaultRole);
        }

        public static void LogUserIn(string username, string role)
        {
            HttpContext.Current.Session[Username] = username;
            HttpContext.Current.Session[Role] = role;
        }

        /// <summary>
        /// Shuts down Current user session.
        /// </summary>
        public static void LogUserOut()
        {
            HttpContext.Current.Session.Abandon();
        }


        public static bool IsUserLoggedIn()
        {
            if(HttpContext.Current.Session[Username] == null)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Returns the username of the currently logged in user or NULL
        /// </summary>
        /// <returns>Username or NULL</returns>
        public static string GetUserName()
        {
            if (IsUserLoggedIn())
            {
                return HttpContext.Current.Session[Username].ToString();
            }
            return null;

        }

        public static bool IsAdmin()
        {
            string role = HttpContext.Current.Session[Role].ToString();

            if(role == Administrator)
            {
                return true;
            }
            return false;
        }
    }


}