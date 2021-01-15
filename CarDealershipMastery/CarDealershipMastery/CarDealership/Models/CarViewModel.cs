using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public List<Car> Cars { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
        public string Year { get; set; }
        public int MakeId { get; set; }
        public string MakeType { get; set; }
        public int ModelId { get; set; }
        public string ModelType { get; set; }
        public int BodyStyleId { get; set; }
        public string Style { get; set; }
        public int TransmissionId { get; set; }
        public string TransmissionType { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int InteriorId { get; set; }
        public string InteriorColor { get; set; }
        public string Milage { get; set; }
        public string VIN { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public string UploadedPicture { get; set; }
        public bool IsFeatured { get; set; }
    }
}