using CarDealership.Data.ADO;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            //Reset the test data.
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand
                {
                    CommandText = "DbReset",
                    CommandType = System.Data.CommandType.StoredProcedure,

                    Connection = cn
                };
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new StateRepositoryADO();

            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count);

            Assert.AreEqual(1, states[0].StateId);
            Assert.AreEqual("Ohio", states[0].StateName);
        }

        [Test]
        public void CanLoadColors()
        {
            var repo = new ColorRepositoryADO();

            var colors = repo.GetAll();

            Assert.AreEqual(5, colors.Count);

            Assert.AreEqual(1, colors[0].ColorId);
            Assert.AreEqual("Red", colors[0].ColorName);
        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new BodyStyleRepositoryADO();

            var styles = repo.GetAll();

            Assert.AreEqual(3, styles.Count);

            Assert.AreEqual(1, styles[0].BodyStyleId);
            Assert.AreEqual("Car", styles[0].Style);
        }





        [Test]
        public void CanLoadContacts()
        {
            var repo = new ContactRepositoryADO();

            var contact = repo.GetById(2);

            Assert.IsNotNull(contact);

            //2, 'Nipsey Hussle', 'tmc@gmail.com', '222-222-2222', 'Let me buy the whole please!!!
            Assert.AreEqual(2, contact.ContactId);
            Assert.AreEqual("Nipsey Hussle", contact.Name);
            Assert.AreEqual("tmc@gmail.com", contact.Email);
            Assert.AreEqual("222-222-2222", contact.Phone);
            Assert.AreEqual("Let me buy the whole please!!!", contact.Message);
        }

        [Test]
        public void ContactIsNull()
        {
            var repo = new ContactRepositoryADO();

            var contact = repo.GetById(100000000);

            Assert.IsNull(contact);
        }


        [Test]
        public void CanLoadMakes()
        {
            var repo = new MakeRepositoryADO();
            var make = repo.GetById(1);

            Assert.IsNotNull(make);

            Assert.AreEqual(1, make.MakeId);
            Assert.AreEqual("Ram", make.MakeType);
        }


        [Test]
        public void MakeIsNull()
        {
            var repo = new MakeRepositoryADO();
            var make = repo.GetById(1000000);

            Assert.IsNull(make);
        }

        [Test]
        public void ModelCanLoad()
        {
            var repo = new ModelRepositoryADO();

            var model = repo.GetById(1);

            Assert.IsNotNull(model);

            Assert.AreEqual(1, model.ModelId);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", model.UserId);
            Assert.AreEqual("Dodge", model.ModelType);
        }

        [Test]
        public void ModelIsNull()
        {
            var repo = new ModelRepositoryADO();

            var model = repo.GetById(100000);

            Assert.IsNull(model);
        }

        [Test]
        public void CanLoadSalesInfo()
        {
            var repo = new SalesInfoRepositoryADO();

            var sales = repo.GetById(2);

            Assert.IsNotNull(sales);

            Assert.AreEqual(2, sales.SalesInfoId);
            Assert.AreEqual("dp", sales.UserId);
            Assert.AreEqual("Kaden", sales.Name);
            Assert.AreEqual("SupercoolKid@gmail.com", sales.Email);
            Assert.AreEqual("King Street Ln", sales.Street1);
            Assert.AreEqual("Main Street Ave", sales.Street2);
            Assert.AreEqual("Louisville", sales.City);
            Assert.AreEqual(2, sales.StateId);
            Assert.AreEqual(40299, sales.ZipCode);
            Assert.AreEqual(200000M, sales.PurchasePrice);
            Assert.AreEqual(2, sales.PurchaseTypeId);
        }

        [Test]
        public void SalesInfoIsNull()
        {
            var repo = new SalesInfoRepositoryADO();

            var sales = repo.GetById(200000);

            Assert.IsNull(sales);
        }


        [Test]
        public void SpecialsCanLoad()
        {
            var repo = new SpecialsRepositoryADO();

            var specials = repo.GetById(1);

            Assert.IsNotNull(specials);

            //1, 'Spring Break Deals', '25% off any car for students'
            Assert.AreEqual(1, specials.SpecialsId);
            Assert.AreEqual("Spring Break Deals", specials.Title);
            Assert.AreEqual("25% off any car for students", specials.Description);
        }

        [Test]
        public void SpecialsIsNull()
        {
            var repo = new SpecialsRepositoryADO();

            var specials = repo.GetById(1000000);

            Assert.IsNull(specials);
        }

        // Car Tests.
        [Test]
        public void CarIsNull()
        {
            var repo = new CarRepositoryADO();

            var car = repo.GetByDetails(100000000);

            Assert.IsNull(car);
        }

        [Test]
        public void CanLoadCarById()
        {
            var repo = new CarRepositoryADO();

            var car = repo.GetByDetails(1);

            Assert.IsNotNull(car);

            //1, '00000000-0000-0000-0000-000000000000', 1, 1, 1, 1, 1, 2, 2, '2020', 'New', '1TD67UHY89IT5RE2D', 150.00, 135.00, 'Brand New Car', 'Image file path', 0
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", car.UserId);
            Assert.AreEqual(1, car.MakeId);
            Assert.AreEqual(1, car.ModelId);
            Assert.AreEqual(1, car.TypeId);
            Assert.AreEqual(1, car.BodyStyleId);
            Assert.AreEqual(1, car.TransmissionId);
            Assert.AreEqual(2, car.ColorId);
            Assert.AreEqual(2, car.InteriorId);
            Assert.AreEqual("2020", car.Year);
            Assert.AreEqual("New", car.Milage);
            Assert.AreEqual("1TD67UHY89IT5RE2D", car.VIN);
            Assert.AreEqual(150M, car.MSRP);
            Assert.AreEqual(135M, car.SalePrice);
            Assert.AreEqual("Brand New Car", car.Description);
            Assert.AreEqual("placeholder.png", car.UploadedPicture);
            Assert.AreEqual(true, car.IsFeatured);

        }

        [Test]
        public void CanAddCar()
        {
            Car carToAdd = new Car();
            var repo = new CarRepositoryADO();

            carToAdd.CarId = 1;
            carToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            carToAdd.MakeId = 1;
            carToAdd.ModelId = 1;
            carToAdd.TypeId = 1;
            carToAdd.BodyStyleId = 1;
            carToAdd.TransmissionId = 1;
            carToAdd.ColorId = 1;
            carToAdd.InteriorId = 1;
            carToAdd.Year = "1988";
            carToAdd.Milage = "157,789";
            carToAdd.VIN = "1TD67UHY89IT5RE2D";
            carToAdd.MSRP = 10M;
            carToAdd.SalePrice = 5M;
            carToAdd.Description = "Older Car but drives new!!!";
            carToAdd.UploadedPicture = "placeholder.png";
            carToAdd.IsFeatured = false;


            repo.Insert(carToAdd);

            Assert.AreEqual(9, carToAdd.CarId);
        }


        [Test]
        public void CanUpdateCar()
        {
            Car carToAdd = new Car();
            var repo = new CarRepositoryADO();

            carToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            carToAdd.MakeId = 1;
            carToAdd.ModelId = 1;
            carToAdd.TypeId = 1;
            carToAdd.BodyStyleId = 1;
            carToAdd.TransmissionId = 1;
            carToAdd.ColorId = 1;
            carToAdd.InteriorId = 1;
            carToAdd.Year = "1988";
            carToAdd.Milage = "157,789";
            carToAdd.VIN = "1TD67UHY89IT5RE2D";
            carToAdd.MSRP = 10M;
            carToAdd.SalePrice = 5M;
            carToAdd.Description = "Older Car but drives new!!!";
            carToAdd.UploadedPicture = "placeholder.png";
            carToAdd.IsFeatured = true;


            repo.Insert(carToAdd);

            carToAdd.Description = "A bucket with 4 wheels.";
            carToAdd.MSRP = 1M;
            carToAdd.SalePrice = 1M;

            repo.Update(carToAdd);

            var updatedCar = repo.GetByDetails(9);
            Assert.AreEqual("A bucket with 4 wheels.", updatedCar.Description);
            Assert.AreEqual(1M, updatedCar.MSRP);
            Assert.AreEqual(1M, updatedCar.SalePrice);

        }


        [Test]
        public void CanDeleteCar()
        {
            Car carToAdd = new Car();
            var repo = new CarRepositoryADO();

            carToAdd.CarId = 1;
            carToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            carToAdd.MakeId = 1;
            carToAdd.ModelId = 1;
            carToAdd.TypeId = 1;
            carToAdd.BodyStyleId = 1;
            carToAdd.TransmissionId = 1;
            carToAdd.ColorId = 1;
            carToAdd.InteriorId = 1;
            carToAdd.Year = "1988";
            carToAdd.Milage = "157,789";
            carToAdd.VIN = "1TD67UHY89IT5RE2D";
            carToAdd.MSRP = 10M;
            carToAdd.SalePrice = 5M;
            carToAdd.Description = "Older Car but drives new!!!";
            carToAdd.UploadedPicture = "placeholder.png";
            carToAdd.IsFeatured = true;


            repo.Insert(carToAdd);

            var loaded = repo.GetByDetails(9);
            Assert.IsNotNull(loaded);

            repo.Delete(9);
            loaded = repo.GetByDetails(9);

            Assert.IsNull(loaded);
        }


        // Contacts Tests.
        [Test]
        public void CanAddNewContact()
        {
            Contact contactToAdd = new Contact();
            var repo = new ContactRepositoryADO();

            contactToAdd.Name = "Mr.Peele";
            contactToAdd.Email = "brownSpots@fornite.com";
            contactToAdd.Phone = "B-A-N-A-N-A";
            contactToAdd.Message = "Banana in pajamas";



            repo.Insert(contactToAdd);

            Assert.AreEqual(4, contactToAdd.ContactId);
        }


        [Test]
        public void CanUpdateContact()
        {
            Contact contactToAdd = new Contact();
            var repo = new ContactRepositoryADO();

            contactToAdd.Name = "Mr.Peele";
            contactToAdd.Email = "brownSpots@fornite.com";
            contactToAdd.Phone = "B-A-N-A-N-A";
            contactToAdd.Message = "Banana in pajamas";



            repo.Insert(contactToAdd);

            contactToAdd.Name = "Banana Agent";

            repo.Update(contactToAdd);

            var updatedContact = repo.GetById(4);
            Assert.AreEqual("Banana Agent", updatedContact.Name);
        }

        [Test]
        public void CanDeleteContact()
        {
            Contact contactToAdd = new Contact();
            var repo = new ContactRepositoryADO();

            contactToAdd.Name = "Mr.Peele";
            contactToAdd.Email = "brownSpots@fornite.com";
            contactToAdd.Phone = "B-A-N-A-N-A";
            contactToAdd.Message = "Banana in pajamas";



            repo.Insert(contactToAdd);

            var loaded = repo.GetById(4);
            Assert.IsNotNull(loaded);

            repo.Delete(4);
            loaded = repo.GetById(4);

            Assert.IsNull(loaded);
        }


        [Test]
        public void CanAddNewMake()
        {
            Make makeToAdd = new Make();
            var repo = new MakeRepositoryADO();

            makeToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            makeToAdd.MakeType = "Telsa";

            repo.Insert(makeToAdd);

            Assert.AreEqual(4, makeToAdd.MakeId);
        }

        [Test]
        public void CanAddModel()
        {
            Model modelToAdd = new Model();
            var repo = new ModelRepositoryADO();

            modelToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            modelToAdd.ModelType = "CyberTruck";

            repo.Insert(modelToAdd);

            Assert.AreEqual(4, modelToAdd.ModelId);
        }

        [Test]
        public void CanAddSalesInfo()
        {
            SalesInfo infoToAdd = new SalesInfo();
            var repo = new SalesInfoRepositoryADO();

            infoToAdd.CarId = 1;
            infoToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            infoToAdd.Name = "John Wick";
            infoToAdd.Email = "iLoveDogs@ruff.com";
            infoToAdd.Street1 = "Anywhere";
            infoToAdd.Street2 = "Continental Hotel";
            infoToAdd.City = "Louisville";
            infoToAdd.StateId = 1;
            infoToAdd.ZipCode = 42099;
            infoToAdd.PurchasePrice = 15300M;
            infoToAdd.PurchaseTypeId = 2;

            repo.Insert(infoToAdd);

            Assert.AreEqual(3, infoToAdd.SalesInfoId);
        }

        [Test]
        public void CanAddSpecials()
        {
            Specials specialsToAdd = new Specials();
            var repo = new SpecialsRepositoryADO();

            specialsToAdd.Title = "Just Cause We Can Sell";
            specialsToAdd.Description = "Let's talk things over shall we.";

            repo.Insert(specialsToAdd);

            Assert.AreEqual(4, specialsToAdd.SpecialsId);
        }





        [Test]
        public void CanUpdateMake()
        {
            Make makeToAdd = new Make();
            var repo = new MakeRepositoryADO();

            makeToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            makeToAdd.MakeType = "telsa";

            repo.Insert(makeToAdd);

            makeToAdd.MakeType = "Telsa";
            repo.Update(makeToAdd);

            var updatedMake = repo.GetById(4);
            Assert.AreEqual("Telsa", updatedMake.MakeType);
        }

        [Test]
        public void CanUpdateModel()
        {
            Model modelToAdd = new Model();
            var repo = new ModelRepositoryADO();

            modelToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            modelToAdd.ModelType = "CyberTruck";

            repo.Insert(modelToAdd);

            modelToAdd.ModelType = "Cyber Truck";
            repo.Update(modelToAdd);

            var updatedModel = repo.GetById(4);
            Assert.AreEqual("Cyber Truck", updatedModel.ModelType);
        }

        [Test]
        public void CanUpdateSalesInfo()
        {
            SalesInfo infoToAdd = new SalesInfo();
            var repo = new SalesInfoRepositoryADO();

            infoToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            infoToAdd.Name = "John Wick";
            infoToAdd.Email = "iLoveDogs@ruff.com";
            infoToAdd.Street1 = "Anywhere";
            infoToAdd.Street2 = "Continental Hotel";
            infoToAdd.City = "Louisville";
            infoToAdd.StateId = 1;
            infoToAdd.ZipCode = 42099;
            infoToAdd.PurchasePrice = 15300M;
            infoToAdd.PurchaseTypeId = 2;

            repo.Insert(infoToAdd);

            infoToAdd.ZipCode = 40299;

            repo.Update(infoToAdd);
            var updatedInfo = repo.GetById(3);
            Assert.AreEqual(40299, updatedInfo.ZipCode);

        }

        [Test]
        public void CanUpdateSpecials()
        {
            Specials specialsToAdd = new Specials();
            var repo = new SpecialsRepositoryADO();

            specialsToAdd.Title = "Just Cause We Can Sell";
            specialsToAdd.Description = "Let's talk things over shall we.";

            repo.Insert(specialsToAdd);

            specialsToAdd.Description = "Today will be the best day to talk down a price tag.";

            repo.Update(specialsToAdd);

            var updatedSpecials = repo.GetById(4);
            Assert.AreEqual("Today will be the best day to talk down a price tag.", updatedSpecials.Description);
        }


        [Test]
        public void CanDeleteMake()
        {
            Make makeToAdd = new Make();
            var repo = new MakeRepositoryADO();

            makeToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            makeToAdd.MakeType = "telsa";

            repo.Insert(makeToAdd);

            var loaded = repo.GetById(4);
            Assert.IsNotNull(loaded);

            repo.Delete(4);
            loaded = repo.GetById(4);

            Assert.IsNull(loaded);

        }

        [Test]
        public void CanDeleteModel()
        {
            Model modelToAdd = new Model();
            var repo = new ModelRepositoryADO();

            modelToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            modelToAdd.ModelType = "CyberTruck";

            repo.Insert(modelToAdd);

            var loaded = repo.GetById(4);
            Assert.IsNotNull(loaded);

            repo.Delete(4);
            loaded = repo.GetById(4);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanDeleteSalesInfo()
        {
            SalesInfo infoToAdd = new SalesInfo();
            var repo = new SalesInfoRepositoryADO();

            infoToAdd.UserId = "00000000-0000-0000-0000-000000000000";
            infoToAdd.CarId = 1;
            infoToAdd.Name = "John Wick";
            infoToAdd.Email = "iLoveDogs@ruff.com";
            infoToAdd.Street1 = "Anywhere";
            infoToAdd.Street2 = "Continental Hotel";
            infoToAdd.City = "Louisville";
            infoToAdd.StateId = 1;
            infoToAdd.ZipCode = 42099;
            infoToAdd.PurchasePrice = 15300M;
            infoToAdd.PurchaseTypeId = 2;

            repo.Insert(infoToAdd);

            var loaded = repo.GetById(3);
            Assert.IsNotNull(loaded);

            repo.Delete(3);
            loaded = repo.GetById(3);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanDeleteSpecials()
        {
            Specials specialsToAdd = new Specials();
            var repo = new SpecialsRepositoryADO();

            specialsToAdd.Title = "Just Cause We Can Sell";
            specialsToAdd.Description = "Let's talk things over shall we.";

            repo.Insert(specialsToAdd);

            var loaded = repo.GetById(3);
            Assert.IsNotNull(loaded);

            repo.Delete(3);
            loaded = repo.GetById(3);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanLoadRecentCar()
        {
            var repo = new CarRepositoryADO();
            List<CarItem> car = repo.GetRecent().ToList();

            Assert.AreEqual(8, car.Count());

            Assert.AreEqual(8, car[0].CarId);
            Assert.AreEqual("dp", car[0].UserId);
            Assert.AreEqual("2020", car[0].Year);
            Assert.AreEqual(1, car[0].MakeId);
            Assert.AreEqual(1, car[0].ModelId);
            Assert.AreEqual(125M, car[0].SalePrice);
            Assert.AreEqual("placeholder.png", car[0].UploadedPicture);

        }

        [Test]
        public void CanLoadCarDetails()
        {
            var repo = new CarRepositoryADO();

            var car = repo.GetByDetails(1);

            Assert.IsNotNull(car);
            Assert.AreEqual(1, car.CarId);
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", car.UserId);
            Assert.AreEqual(1, car.MakeId);
            Assert.AreEqual(1, car.ModelId);
            Assert.AreEqual(1, car.BodyStyleId);
            Assert.AreEqual(1, car.TransmissionId);
            Assert.AreEqual(2, car.ColorId);
            Assert.AreEqual(2, car.InteriorId);
            Assert.AreEqual("2020", car.Year);
            Assert.AreEqual("New", car.Milage);
            Assert.AreEqual("1TD67UHY89IT5RE2D", car.VIN);
            Assert.AreEqual(150M, car.MSRP);
            Assert.AreEqual(135M, car.SalePrice);
            Assert.AreEqual("Brand New Car", car.Description);
            Assert.AreEqual("placeholder.png", car.UploadedPicture);

        }

        [Test]
        public void CanLoadRecentSpecials()
        {
            var repo = new SpecialsRepositoryADO();
            List<Specials> sp = repo.GetSpecials().ToList();

            Assert.AreEqual(3, sp.Count());

            Assert.AreEqual(1, sp[0].SpecialsId);
            Assert.AreEqual("Spring Break Deals", sp[0].Title);
            Assert.AreEqual("25% off any car for students", sp[0].Description);
        }

        [Test]
        public void CanTestCarSearchParams()
        {
            var repo = new CarRepositoryADO();

            var found = repo.Search(new CarSearchParams { MinYear = "2020" });

            Assert.AreEqual(8, found.Count());
        }

    }
}

