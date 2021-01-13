using CarDealership.Data.Factories;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Details(int id)
        {
            var repo = CarRepositoryFactory.GetRepository();
            var model = repo.GetDetails(id);

            return View(model);
        }

        public ActionResult Search()
        {
            CarViewModel carViewModel = new CarViewModel();

            var carRepo = CarRepositoryFactory.GetRepository();

            var carList = carRepo.GetAllCars();

            List<CarViewModel> carVMList = carList.Select(x => new CarViewModel
            {
                CarId = x.CarId,
                Year = x.Year,
                MakeType = x.MakeType,
                ModelType = x.ModelType,
                Style = x.Style,
                TransmissionType = x.TransmissionType,
                ColorName = x.ColorName,
                InteriorColor = x.InteriorColor,
                Milage = x.Milage,
                VIN = x.VIN,
                SalePrice = x.SalePrice,
                MSRP = x.MSRP,
                UploadedPicture = x.UploadedPicture
            }).ToList();

            return View(carVMList);
        }
    }
}