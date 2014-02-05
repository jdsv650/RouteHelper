using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDLRouteHelper.Models;
using CDLRouteHelper.Adapters.Data;
using CDLRouteHelper.Data.Model;
using System.Web.Script.Serialization;
using System.Device.Location;

namespace CDLRouteHelper.Controllers
{
    [Authorize]
    public class RestrictedController : Controller
    {
        RestrictedAdapter _adapter;
 
        public RestrictedController()
        {
            _adapter = new RestrictedAdapter();
        }

        [HttpPost]
        public ActionResult SearchByCoords(RetrieveViewModel rvm)
        {
            List<CDLRouteHelper.Models.CreateViewModel> lcvm = new List<CDLRouteHelper.Models.CreateViewModel>();

            if (ModelState.IsValid)  // required fields entered?
            {
                rvm.Distance = 50;  //start at within 50 miles
                ViewBag.lat = rvm.Latitude;
                ViewBag.lon = rvm.Longitude;

                lcvm = _adapter.GetListViewModel(rvm);

                if (lcvm == null) // not found
                    return View();
                else
                    return View("DisplayByCoords", lcvm);
            }

            return View();
        }

        [HttpGet]
        public ActionResult SearchByCoords()
        {
            return View();
        }


        public ActionResult UpdateByCity(double lat, double lon)
        {
            RetrieveViewModel rvm = new RetrieveViewModel();
            rvm.Latitude = lat;
            rvm.Longitude = lon;

            if (ModelState.IsValid)  // required fields entered?
            {
                return View("Update", _adapter.GetCreateViewModel(rvm));
            }

            return View();
        }

        [HttpPost]
        public ActionResult RetrieveByCity(RetrieveByCityViewModel rbcvm)
        {
            DisplayRestrictedViewModel model = new DisplayRestrictedViewModel();

            if (ModelState.IsValid)  // required fields entered?
            {
                model = _adapter.GetDisplayRestrictedViewModelByCityAndState(rbcvm);
                return View("ShowByCity", model);
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Staff, Administrator")]
        public ActionResult RetrieveByCity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(CreateViewModel cvm)
        {
            if (ModelState.IsValid)  // required fields entered?
            {
                _adapter.UpdateCreateViewModel(cvm);
                return View("Retrieve");
            }

            return View();
        }

        [HttpPost]
        public ActionResult DeleteByCoords(CreateViewModel cvm)
        {
            _adapter.DropBridge(cvm);

            return RedirectToAction("Delete", "Restricted");
        }

        [HttpPost]
        public ActionResult Delete(RetrieveViewModel rvm)
        {

            CreateViewModel cvm = new CreateViewModel();

            if (ModelState.IsValid)  // required fields entered?
            {

                cvm = _adapter.GetCreateViewModel(rvm);

                if (cvm == null) // not found
                    return View();
                else
                    return View("DeleteBridge", cvm);
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles="Administrator")]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Retrieve(RetrieveViewModel rvm)
        {
            CreateViewModel cvm = new CreateViewModel();

            if (ModelState.IsValid)  // required fields entered?
            {

                cvm = _adapter.GetCreateViewModel(rvm);

                if (cvm == null) // not found
                    return View();
                else
                    return View("Update", cvm);
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Staff, Administrator")]
        public ActionResult Retrieve()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel cvm)
        {
            if (ModelState.IsValid)  // required fields entered?
            {
                _adapter.SaveCreateViewModel(cvm);
                return RedirectToAction("Create", "Restricted");
            }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RestrictedIndexViewModel rivm)
        {
            DisplayRestrictedViewModel model = new DisplayRestrictedViewModel();

            if (ModelState.IsValid)  // required fields entered?
            {
                model = _adapter.GetDisplayRestrictedViewModel(rivm);

                if (model == null) // not found
                    return View("Index");
                else
                {  
                    model.City = rivm.City;
                    model.State = rivm.State;
                    model.Height = rivm.Height;
                    model.Weight = rivm.Weight;
                    model.Type = rivm.Type;
                    if (model.Type == TruckType.Single)
                        ViewBag.trucktype = "Single";
                    else if (model.Type == TruckType.Double)
                        ViewBag.trucktype = "Double";
                    else
                        ViewBag.trucktype = "Straight";

                    return View("Show", model);
                }
            }
            return View("Index");
        }

        public ActionResult Show(DisplayRestrictedViewModel drvm)
        {
            if (drvm.Type == TruckType.Single)
                ViewBag.trucktype = "Single";
            else if (drvm.Type == TruckType.Double)
                ViewBag.trucktype = "Double";
            else
                ViewBag.trucktype = "Straight";

            return View(drvm);
        }


        public ActionResult Nearby()
        {
            NearbyViewModel nvm = new NearbyViewModel();
            return View(nvm);
        }

        [HttpPost]
        public JsonResult GetList(double latitude, double longitude, float distance)
        {

            CDLRouteHelper.Adapters.Service.ServiceBridge _adapter = new CDLRouteHelper.Adapters.Service.ServiceBridge();
            List<CDLRouteHelper.Models.Service.BridgeServiceModel> lbsm = new List<CDLRouteHelper.Models.Service.BridgeServiceModel>();

            lbsm = _adapter.GetListByDistanceFrom(latitude, longitude, distance);
            return Json(lbsm);

            //CDLRouteHelper.Models.Service.BridgeServiceModel bsm = new CDLRouteHelper.Models.Service.BridgeServiceModel();
            //bsm.Latitude = latitude;
            //bsm.Longitude = longitude;

            //return Json(new { latitude = lbsm[0].Latitude, longitude = lbsm[0].Longitude });
            //return Json(new { foo = "foo", bar = "barrrrr" });
        }

        [HttpPost]
        public JsonResult GetListByAll(double latitude, double longitude, float height, float weight, string trucktype, float distance)
        {
            List<CDLRouteHelper.Models.Service.BridgeServiceModel> lbsm = new List<CDLRouteHelper.Models.Service.BridgeServiceModel>();


            lbsm = _adapter.GetListBridgesByAll(latitude, longitude, height, weight, trucktype, distance);

           // bridges.Add(new Bridge { Address1 = "f32df2", City = "SomeCity", Latitude=43.17296218, Longitude=-78.696838});

            return Json(lbsm); 
        }

        [HttpPost]
        public JsonResult GetListCoordsAsString(string latLng, float distance)
        {
            double lat = CDLRouteHelper.Helper.GeoHelper.LatLonToLatDouble(latLng);
            double lon = CDLRouteHelper.Helper.GeoHelper.LatLonToLonDouble(latLng);

            CDLRouteHelper.Adapters.Service.ServiceBridge _adapter = new CDLRouteHelper.Adapters.Service.ServiceBridge();
            List<CDLRouteHelper.Models.Service.BridgeServiceModel> lbsm = new List<CDLRouteHelper.Models.Service.BridgeServiceModel>();

            CDLRouteHelper.Services.BridgeService bs = new CDLRouteHelper.Services.BridgeService();

            //lbsm = _adapter.GetListByDistanceFrom(lat, lon, distance);

            return Json(bs.ListByDistanceFrom(lat, lon, distance));
        }

    }
}
