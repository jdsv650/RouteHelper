using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDLRouteHelper.Adapters.Interface;
using CDLRouteHelper.Data;
using CDLRouteHelper.Adapters.Data;

namespace CDLRouteHelper.Adapters.Data
{
    public class UserAdapter : IUserAdapter
    {

        public UserData GetUserDataFromUserId(int userId)
        {
            CDLContext db = new CDLContext();

            var user = db.User
                .First(u => u.UserId == userId);

            UserData result = new UserData();
            result.Email = user.Email;
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.UserId = user.UserId;
            result.Username = user.Username;

            result.Roles = db.UserRole
                .Where(userRole => userRole.UserId == userId)
                .Select(userRole => userRole.Role.Name)
                .ToArray();

            return result;
        }
    }
}