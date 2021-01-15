using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    /// <summary>
    /// Represents the model parameters when user search for car.
    /// </summary>
    public class CarSearchParams
    {
        public int? MakeId { get; set; }
        public int? ModelId  { get; set; }
        public int? Year { get; set; }
        public string MinYear { get; set; }
        public string  MaxYear { get; set; }
        public string Mileage { get; set; }
        public string OnSale { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
    }
}
