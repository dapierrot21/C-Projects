using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class CarItem
    {
        public int CarId { get; set; }
        public string UserId { get; set; }
        public string Year { get; set; }
        public int MakeId { get; set; }
        public string MakeType { get; set; }
        public int ModelId { get; set; }
        public string ModelType { get; set; }
        public decimal SalePrice { get; set; }
        public string UploadedPicture { get; set; }
    }
}
