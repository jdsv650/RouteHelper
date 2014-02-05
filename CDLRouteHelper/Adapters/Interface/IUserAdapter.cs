using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDLRouteHelper.Adapters.Interface
{
    interface IUserAdapter
    {
       UserData GetUserDataFromUserId(int userId);

    }
}
