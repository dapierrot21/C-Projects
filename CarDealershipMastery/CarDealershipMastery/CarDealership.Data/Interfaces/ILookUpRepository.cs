using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface ILookUpRepository
    {
        IEnumerable<Car> InventoryReport();
        IEnumerable<Make> MakeReport();
        IEnumerable<Role> UserReport(string userId);
        IEnumerable<Model> ModelReport();
        IEnumerable<SalesInfo> SalesReport();

    }
}
