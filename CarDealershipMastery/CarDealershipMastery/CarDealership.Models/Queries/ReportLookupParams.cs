using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class ReportLookupParams
    {
        public string User { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
