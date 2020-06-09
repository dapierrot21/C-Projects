using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hat.Model
{
    public class HatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Cost { get; set; }
        public bool InStock { get; set; }
    }
}
