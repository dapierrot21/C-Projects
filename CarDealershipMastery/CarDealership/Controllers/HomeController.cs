using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Data.ADO;
using CarDealership.Data.Factories;
using CarDealership.Models.Tables;

namespace CarDealership.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = CarRepositoryFactory.GetRepository().GetRecent();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string vin)
        {
            var model = new Contact();

            ViewBag.Message = vin;

            return View();
        }

    }
}