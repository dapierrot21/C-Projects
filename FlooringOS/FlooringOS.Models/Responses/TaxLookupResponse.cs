using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Models.Responses
{
    public class TaxLookupResponse : Response
    {
        public TaxFile TaxFile { get; set; }
    }
}
