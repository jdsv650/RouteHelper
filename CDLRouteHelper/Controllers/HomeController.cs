using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDLRouteHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Test()
        {
            Adapters.Service.ServiceBridge _adapter = new Adapters.Service.ServiceBridge();


            var l1 = _adapter.GetListByDistanceFrom(29.5324287f, -95.26932f, 2);
            var l2 = _adapter.GetListByDistanceFrom(29.5324287f, -95.26932f, 10);
            var l3 = _adapter.GetListByDistanceFrom(29.5324287f, -95.26932f, 25);
            var l4 = _adapter.GetListByDistanceFrom(29.5324287f, -95.26932f, 1100);

            //var l = _adapter.GetListBridgeServiceModel();

            return null;
        }


        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
