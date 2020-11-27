using CarDealership.Data.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADO
{
    public class LookUpRepositoryADO : ILookUpRepository
    {
        public IEnumerable<Car> InventoryReport()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Make> MakeReport()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model> ModelReport()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesInfo> SalesReport()
        {
            throw new NotImplementedException();
        }
    }
}
