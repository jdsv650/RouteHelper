using CDLRouteHelper.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using CDLRouteHelper.Adapters.Interface;
using CDLRouteHelper.Adapters.Data;

public class UserData
{
        public static UserData Current
        {
            get
            {
                UserData result = HttpContext.Current.Session["CurrentUser"] as UserData;

                if (result == null && WebSecurity.IsAuthenticated)
                {
                    result = InitializeCurrentUserById(WebSecurity.CurrentUserId);
                }

                return result;
            }
            private set
            {
                HttpContext.Current.Session["CurrentUser"] = value;
            }
        }

        public static UserData InitializeCurrentUserById(int userId)
        {
            // Get an instance of our UserAdapter
            IUserAdapter _userAdapter = new UserAdapter();

            // Get a UserProfile using the current userId by calling 
            // a function on the User Adapter
            UserData u = _userAdapter.GetUserDataFromUserId(userId);

            // Set the current user in Session
            // to the returned profile
            UserData.Current = u;

            // return the UserProfile
            return u;

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }

        public string[] Roles { get; set; }

        public static bool IsAdmin
        {
            get { return Current.Roles.Any(r => r == Role.ADMINISTRATOR); }
        }

        internal static void Logout()
        {
            Current = null;
        }
}