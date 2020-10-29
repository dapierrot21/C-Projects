using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Car
    {
        public int CarId { get; set; }
        public string UserId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int TypeId { get; set; }
        public int BodyStyleId { get; set; }
        public int TransmissionId { get; set; }
        public int ColorId { get; set; }
        public int InteriorId { get; set; }
        public string Year { get; set; }
        public string Milage { get; set; }
        public int VIN { get; set; }
        public int MSRP { get; set; }
        public decimal SalePrice { get; set; }
        public string Desciption { get; set; }
        public string UploadedPicture { get; set; }
        public bool IsFeatured { get; set; }
    }
}
