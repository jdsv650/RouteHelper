using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDLRouteHelper.Data;
using CDLRouteHelper.Data.Model;
using System.Device.Location;

namespace CDLRouteHelper.Adapters.Data
{
    public class RestrictedAdapter : CDLRouteHelper.Adapters.Interface.IRestrictedAdapter
    {

        public Models.DisplayRestrictedViewModel GetDisplayRestrictedViewModel(Models.RestrictedIndexViewModel rivm)
        {
            CDLContext db = new CDLContext();

            Models.DisplayRestrictedViewModel drvm = new Models.DisplayRestrictedViewModel();
            List<Bridge> bridges = new List<Bridge>();

            //"Straight Truck", "Single Trailer", "Double Trailer"
            if (rivm.SelectedTruckType == "Single Trailer")
                rivm.Type = TruckType.Single;
            else if (rivm.SelectedTruckType == "Double Trailer")
                rivm.Type = TruckType.Double;
            else                                     // (rivm.SelectedTruckType == "Straight Truck")
                rivm.Type = TruckType.Straight;

            drvm.Bridges = bridges;  // list of bridges to populate for new view model

            drvm.Bridges = db.Bridge.Where(b => ((b.Height <= rivm.Height) || b.Weights.Any(w => w.maxWeight <= rivm.Weight && w.TruckType == rivm.Type))
                                              && (b.State.PostalCode == rivm.State && b.City == rivm.City)).ToList();

            return drvm;
        }

        public List<CDLRouteHelper.Models.Service.BridgeServiceModel> GetListBridgesByAll(double latitude, double longitude, float height, float weight, string trucktype, float distance)
        {
            List<Bridge> bFoundL = new List<Bridge>();
            List<CDLRouteHelper.Models.Service.BridgeServiceModel> lbsm = new List<CDLRouteHelper.Models.Service.BridgeServiceModel>();

            CDLContext db = new CDLContext();
            TruckType tType;

            //"Straight Truck", "Single Trailer", "Double Trailer"
            if (trucktype == "Single")
                tType = TruckType.Single;
            else if (trucktype == "Double")
                tType = TruckType.Double;
            else                           // (tType == "Straight Truck")
                tType = TruckType.Straight;

            bFoundL = db.Bridge.Where(b => ((b.Height <= height) || b.Weights.Any(w => w.maxWeight <= weight && w.TruckType == tType))).ToList();

            var gc = new GeoCoordinate();
            gc.Latitude = latitude;
            gc.Longitude = longitude;

            foreach (var b in bFoundL)
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

                bsm.heightRestriction = (float)b.Height;

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


                if (bridgeGC.GetDistanceTo(gc) <= distance * 1609.344)  // within distance passsed in keep it
                {
                    lbsm.Add(bsm);
                }
            }
        
            //bReturnL.Add(new Bridge { Address1 = "f32df2", City = "SomeCity", Latitude=43.17296218, Longitude=-78.696838, BridgeId=1});
            //bReturnL.Add(new Bridge { Address1 = "f32df2", City = "SomeCity", Latitude = 43.1837882995605, Longitude = -78.6621017456055 });

            return lbsm;
        }

        public Models.DisplayRestrictedViewModel GetDisplayRestrictedViewModelByCityAndState(Models.RetrieveByCityViewModel rbcvm)
        {
            CDLContext db = new CDLContext();

            Models.DisplayRestrictedViewModel drvm = new Models.DisplayRestrictedViewModel();
            List<Bridge> bridges = new List<Bridge>();

            drvm.Bridges = bridges;  // list of bridges to populate for new view model

            drvm.Bridges = db.Bridge.Where(b => (b.State.PostalCode == rbcvm.State && b.City == rbcvm.City)).ToList();

            return drvm;
        }


        public void SaveCreateViewModel(Models.CreateViewModel cvm)
        {
            CDLContext db = new CDLContext();
            Bridge bridge = new Bridge();
            List<Weight> weights = new List<Weight>();
            Weight weight1 = new Weight();
            Weight weight2 = new Weight();
            Weight weight3 = new Weight();
            State st = new State();

            st = db.State.Where(s => cvm.State == s.PostalCode).FirstOrDefault();

            bridge.Address1 = cvm.Address1;
            bridge.City = cvm.City;
            bridge.State = st;
            bridge.PostalCode = cvm.PostalCode;
            bridge.LastUpdated = DateTime.UtcNow;
            bridge.Height = cvm.Height;

            bridge.Latitude = cvm.Latitude;
            bridge.Longitude = cvm.Longitude;

            weight1.maxWeight = cvm.WeightStraight;
            weight1.TruckType = TruckType.Straight;
            weights.Add(weight1);

            weight2.maxWeight = cvm.WeightSingle;
            weight2.TruckType = TruckType.Single;
            weights.Add(weight2);

            weight3.maxWeight = cvm.WeightDouble;
            weight3.TruckType = TruckType.Double;
            weights.Add(weight3);

            bridge.Weights = weights;

            db.Bridge.Add(bridge);
            db.SaveChanges();

        }

        public Models.CreateViewModel GetCreateViewModel(Models.RetrieveViewModel rvm)
        {
            Models.CreateViewModel cvm = new Models.CreateViewModel();
            CDLContext db = new CDLContext();
            Bridge bridge = new Bridge();

            bridge = db.Bridge.Where(b => b.Latitude <= rvm.Latitude + 0.001 && b.Latitude >= rvm.Latitude - 0.001 &&
                                 b.Longitude <= rvm.Longitude + 0.001 && b.Longitude >= rvm.Longitude - 0.001).FirstOrDefault();

            if (bridge != null)  //found match
            {
                cvm.Latitude = bridge.Latitude;
                cvm.Longitude = bridge.Longitude;
                cvm.Address1 = bridge.Address1;
                cvm.City = bridge.City;
                cvm.State = bridge.State.PostalCode;
                cvm.PostalCode = bridge.PostalCode;

                cvm.Height = bridge.Height;
                cvm.BridgeId = bridge.BridgeId;

                if (bridge.Weights.Count >= 1)
                    cvm.WeightStraight = bridge.Weights.ElementAt(0).maxWeight;
                if (bridge.Weights.Count >= 2)
                    cvm.WeightSingle = bridge.Weights.ElementAt(1).maxWeight;
                if (bridge.Weights.Count >= 3)
                    cvm.WeightDouble = bridge.Weights.ElementAt(2).maxWeight;
            }
            else
            { cvm = null; }

            return cvm;
        }


        public void UpdateCreateViewModel(Models.CreateViewModel cvm)
        {
            CDLContext db = new CDLContext();
            Bridge bridge = new Bridge();

            bridge = db.Bridge.Find(cvm.BridgeId);

            State st = new State();
            st = db.State.Where(s => cvm.State == s.PostalCode).FirstOrDefault();

            bridge.Address1 = cvm.Address1;
            bridge.City = cvm.City;
            bridge.State = st;
            bridge.PostalCode = cvm.PostalCode;
            bridge.LastUpdated = DateTime.UtcNow;
            bridge.Height = cvm.Height;

            bridge.Latitude = cvm.Latitude;
            bridge.Longitude = cvm.Longitude;

            if (bridge.Weights.Count >= 1)
                bridge.Weights.ElementAt(0).maxWeight = cvm.WeightStraight;
            if (bridge.Weights.Count >= 2)
                bridge.Weights.ElementAt(1).maxWeight = cvm.WeightSingle;
            if (bridge.Weights.Count >= 3)
                bridge.Weights.ElementAt(2).maxWeight = cvm.WeightDouble;

            db.SaveChanges();
        }





        public List<Models.CreateViewModel> GetListViewModel(Models.RetrieveViewModel rvm)
        {
            List<Models.CreateViewModel> lcvm = new List<Models.CreateViewModel>();
            CDLContext db = new CDLContext();

            GeoCoordinate gc = new GeoCoordinate(rvm.Latitude, rvm.Longitude);

            List<Bridge> bridges = new List<Bridge>();

            bridges = db.Bridge.ToList();

            foreach (var b in bridges)
            {
                var cvm = new Models.CreateViewModel();

                cvm.Address1 = b.Address1;
                cvm.City = b.City;
                cvm.State = b.State.Name;
                cvm.PostalCode = b.PostalCode;

                cvm.Latitude = b.Latitude;
                cvm.Longitude = b.Longitude;

                var bridgeGC = new GeoCoordinate();

                bridgeGC.Latitude = cvm.Latitude;
                bridgeGC.Longitude = cvm.Longitude;

                if (b.Height == null)
                    b.Height = 0;

                cvm.Height = (float)b.Height;

                if (b.Weights.Count >= 1)
                    cvm.WeightStraight = b.Weights.ElementAt(0).maxWeight;
                if (b.Weights.Count >= 2)
                    cvm.WeightSingle = b.Weights.ElementAt(1).maxWeight;
                if (b.Weights.Count >= 3)
                    cvm.WeightDouble = b.Weights.ElementAt(2).maxWeight;

                if (bridgeGC.GetDistanceTo(gc) <= rvm.Distance * 1609.344)  // within distance passsed in keep it
                {
                    lcvm.Add(cvm);
                }
            }

            return lcvm;


        }


        public void DropBridge(Models.CreateViewModel cvm)
        {
            CDLContext db = new CDLContext();
            Bridge bridge = new Bridge();

            bridge = db.Bridge.Find(cvm.BridgeId);

            db.Bridge.Remove(bridge);
            db.SaveChanges();

        }
    }
}