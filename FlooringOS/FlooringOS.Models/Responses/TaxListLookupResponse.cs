using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Models.Responses
{
    public class TaxListLookupResponse : Response
    {
        public List<TaxFile> taxList { get; set; }
    }
}
