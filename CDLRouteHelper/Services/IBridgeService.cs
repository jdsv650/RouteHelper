using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CDLRouteHelper.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBridgeService" in both code and config file together.
    [ServiceContract]
    public interface IBridgeService
    {
        [OperationContract]
        List<Models.Service.BridgeServiceModel> List();

        [OperationContract]
        List<Models.Service.BridgeServiceModel> ListByDistanceFrom(double latitude, double longitude, float distance);
    }
}
