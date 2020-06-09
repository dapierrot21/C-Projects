using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Models
{
    public class TaxFile
    {
        public string StateAbbr { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }
    }
}
