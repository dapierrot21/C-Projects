using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class InventoryReport
    {
        public int InventoryReportId { get; set; }
        public string Year { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int Count { get; set; }
        public int StockValue { get; set; }
        public bool IsSold { get; set; }
    }
}
