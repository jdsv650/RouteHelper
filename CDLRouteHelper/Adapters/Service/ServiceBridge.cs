using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;  //geo
using CDLRouteHelper.Data;
using CDLRouteHelper.Data.Model;

namespace CDLRouteHelper.Adapters.Service
{
    public class ServiceBridge : Adapters.Service.IServiceBridge
    {

        public List<Models.Service.BridgeServiceModel> GetListBridgeServiceModel()
        {
            List<Models.Service.BridgeServiceModel> lbsm = new List<Models.Service.BridgeServiceModel>();
            CDLContext db = new CDLContext();

            List<Bridge> bridges = new List<Bridge>();

            bridges = db.Bridge.ToList();

            foreach(var b in bridges)
            {
                var bsm = new Models.Service.BridgeServiceModel();
                bsm.Guid = b.Guid;
                bsm.Latitude =  b.Latitude;
                bsm.Longitude = b.Longitude;
                bsm.Location = b.Address1;
                bsm.City = b.City;

                if (b.Height == null)
                    b.Height = 0;
                bsm.heightRestriction = (float) b.Height;

                if (b.Weights.Count >= 1)
                    bsm.weightStraightTruck = (float) b.Weights.ElementAt(0).maxWeight;
                if (b.Weights.Count >= 2)
                    bsm.weightSingleTrailer = (float) b.Weights.ElementAt(1).maxWeight;
                if (b.Weights.Count >= 3)
                    bsm.weightDoubleTrailer = (float) b.Weights.ElementAt(2).maxWeight;
         
                lbsm.Add(bsm);
            }
           
            //lbsm = db.Bridge.ToList().Select(b => new { b.Guid, b.Height, b.Latitude, b.Longitude }).ToList();

            return lbsm;
        }


        const double _eQuatorialEarthRadius = 6378.1370D;
        const double _d2r = (Math.PI / 180D);

        //public static double HaversineInM(this double d,  double lat1, double long1, double lat2, double long2)
        //{
        //    return (1000D * HaversineInKM(lat1, long1, lat2, long2));
        //}

        public bool GeoCoordsDistance(double latitude, double longitude, double lat2, double long2, float distance)
        {
            double dlong = ((long2 - longitude) * _d2r);
            double dlat = ((lat2 - latitude) * _d2r);
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(latitude * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = _eQuatorialEarthRadius * c;
 
               if (1000D * _eQuatorialEarthRadius * 2D * Math.Atan2(Math.Sqrt(Math.Pow(Math.Sin(((lat2 - latitude) * _d2r) / 2D), 2D) + Math.Cos(latitude * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(((long2 - longitude) * _d2r) / 2D), 2D)), Math.Sqrt(1D - Math.Pow(Math.Sin(((lat2 - latitude) * _d2r) / 2D), 2D) + Math.Cos(latitude * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(((long2 - longitude) * _d2r) / 2D), 2D))) <= distance)
               {
                   return true;
               }

               return false;
        }


        public List<Models.Service.BridgeServiceModel> GetListByDistanceFrom(double latitude, double longitude, float distance)
        {
            List<Models.Service.BridgeServiceModel> lbsm = new List<Models.Service.BridgeServiceModel>();
            CDLContext db = new CDLContext();

            GeoCoordinate gc = new GeoCoordinate(latitude, longitude);

            List<Bridge> bridges = new List<Bridge>();

            //bridges = db.Bridge.Where(b =>
            // (1000D * _eQuatorialEarthRadius * 2D * Math.Atan2(Math.Sqrt(Math.Pow(Math.Sin((double)((b.Latitude - latitude) * _d2r) / 2D), 2D) + Math.Cos(latitude * _d2r) * Math.Cos((double)b.Latitude * _d2r) * Math.Pow(Math.Sin((double)((b.Longitude - longitude) * _d2r) / 2D), 2D)), Math.Sqrt(1D - Math.Pow(Math.Sin((double)((b.Longitude - latitude) * _d2r) / 2D), 2D) + Math.Cos(latitude * _d2r) * Math.Cos((double)b.Latitude * _d2r) * Math.Pow(Math.Sin((((double)b.Longitude - longitude) * _d2r) / 2D), 2D))) <= distance)
            //== true ).ToList();
             //(1000D * _eQuatorialEarthRadius * 2D * Math.Atan2(Math.Sqrt(Math.Pow(Math.Sin((double)((b.Latitude - latitude) * _d2r) / 2D), 2D) + Math.Cos(latitude * _d2r) * Math.Cos((double)b.Latitude * _d2r) * Math.Pow(Math.Sin((double)((b.Longitude - longitude) * _d2r) / 2D), 2D)), Math.Sqrt(1D - Math.Pow(Math.Sin((double)((b.Longitude - latitude) * _d2r) / 2D), 2D) + Math.Cos(latitude * _d2r) * Math.Cos((double)b.Latitude * _d2r) * Math.Pow(Math.Sin((((double)b.Longitude - longitude) * _d2r) / 2D), 2D))) <= distance)
            
            //bridges = (from b in db.Bridge 
            //          where  (1000D * (b.Latitude - Math.Abs(latitude))  <= distance)
            //          select b).ToList();

            bridges = db.Bridge.ToList();

            foreach (var b in bridges)
            {
                var bsm = new Models.Service.BridgeServiceModel();
                bsm.Guid = b.Guid;
                bsm.Latitude = b.Latitude;
                bsm.Longitude = b.Longitude;
                bsm.Location = b.Address1;
                bsm.City = b.City;

                var bridgeGC = new GeoCoordinate();

                bridgeGC.Latitude = bsm.Latitude;
                bridgeGC.Longitude = bsm.Longitude;

                if (b.Height == null)
                    b.Height = 0;

                bsm.heightRestriction = (float) b.Height;

                if (b.Weights.Count >= 1)
                    if (b.Weights.ElementAt(0).maxWeight != null)
                    {
                        bsm.weightStraightTruck = (float)b.Weights.ElementAt(0).maxWeight; ;
                    }
                if (b.Weights.Count >= 2)
                    if (b.Weights.ElementAt(1).maxWeight != null)
                    {
                        bsm.weightSingleTrailer = (float)b.Weights.ElementAt(1).maxWeight;
                    }
                if (b.Weights.Count >= 3)
                    if (b.Weights.ElementAt(2).maxWeight != null)
                    {
                    bsm.weightDoubleTrailer = (float)b.Weights.ElementAt(2).maxWeight;
                    }
                if(bridgeGC.GetDistanceTo(gc) <= distance * 1609.344)  // within distance passsed in keep it
                {
                    lbsm.Add(bsm);
                }
            }

            return lbsm;
           
        }
    }
}