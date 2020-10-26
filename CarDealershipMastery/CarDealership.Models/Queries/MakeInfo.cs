using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class MakeInfo
    {
        public int MakeId { get; set; }
        public string MakeType { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
    }
}
