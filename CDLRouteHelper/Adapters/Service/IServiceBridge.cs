using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDLRouteHelper.Adapters.Service
{
    interface IServiceBridge
    {
        List<Models.Service.BridgeServiceModel> GetListBridgeServiceModel();

        List<Models.Service.BridgeServiceModel> GetListByDistanceFrom(double latitude, double longitude, float distance);
        
    }
}
