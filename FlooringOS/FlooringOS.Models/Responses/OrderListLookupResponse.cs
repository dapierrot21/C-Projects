using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Models.Responses
{
    public class OrderListLookupResponse : Response
    {
        public List<OrderFile> orderList { get; set; }
    }
}
