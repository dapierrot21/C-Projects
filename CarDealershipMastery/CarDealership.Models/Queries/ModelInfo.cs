using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class ModelInfo
    {
        public int MakeId { get; set; }
        public string MakeType { get; set; }
        public int ModelId { get; set; }
        public string ModelType { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
    }
}
