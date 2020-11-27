using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class InvertoryReportLookUp
    {
        public string UserId { get; set; }
        public string Year { get; set; }
        public int MakeId { get; set; }
        public string MakeType { get; set; }
        public int ModelId { get; set; }
        public string ModelType { get; set; }
        public int Count { get; set; }
        public int StockValue { get; set; }
    }
}
