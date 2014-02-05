using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CDLRouteHelper.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BridgeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BridgeService.svc or BridgeService.svc.cs at the Solution Explorer and start debugging.
    public class BridgeService : IBridgeService
    {
   
        public List<Models.Service.BridgeServiceModel> List()
        {
            List<Models.Service.BridgeServiceModel> bsml = new List<Models.Service.BridgeServiceModel>();

            //bsml.Add(new Models.Service.BridgeServiceModel() {Latitude=39.12211f, Longitude = -105.22f, heightRestriction =13.5f,
            //                                                 weightStraightTruck =25, weightSingleTrailer=28, weightDoubleTrailer=30} );


            Adapters.Service.ServiceBridge adapter = new Adapters.Service.ServiceBridge();
            return bsml = adapter.GetListBridgeServiceModel();
        }


        public List<Models.Service.BridgeServiceModel> ListByDistanceFrom(double latitude, double longitude, float distance)
        {
            List<Models.Service.BridgeServiceModel> bsml = new List<Models.Service.BridgeServiceModel>();
            Adapters.Service.ServiceBridge adapter = new Adapters.Service.ServiceBridge();

            return adapter.GetListByDistanceFrom(latitude, longitude, distance);
        }
    }
}
