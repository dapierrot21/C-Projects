using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface ICarRepository
    {
        Car GetByDetails(int carId);
        void Insert(Car car);
        void Update(Car car);
        void Delete(int CarId);
        IEnumerable<CarItem> GetRecent();
        CarDetails GetDetails(int carId);
    }
}
