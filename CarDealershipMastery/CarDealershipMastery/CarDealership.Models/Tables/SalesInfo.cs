using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class SalesInfo
    {
        public int CarId { get; set; }
        public string UserId { get; set; }
        public int SalesInfoId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public int ZipCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeId { get; set; } 
    }
}
