using CarDealership.Data.Factories;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    /// <summary>
    /// Represents the logic for Inventory Reports.
    /// </summary>
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

            List<CarViewModel> carVMList = carList.Select(car => new CarViewModel
            {
                CarId = car.CarId,
                Year = car.Year,
                MakeType = car.MakeType,
                ModelType = car.ModelType,
                Style = car.Style,
                TransmissionType = car.TransmissionType,
                ColorName = car.ColorName,
                InteriorColor = car.InteriorColor,
                Milage = car.Milage,
                VIN = car.VIN,
                SalePrice = car.SalePrice,
                MSRP = car.MSRP,
                UploadedPicture = car.UploadedPicture
            }).ToList();

            return View(carVMList);
        }
    }
}