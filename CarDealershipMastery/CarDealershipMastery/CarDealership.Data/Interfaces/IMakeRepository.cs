using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IMakeRepository
    {
        Make GetById(int makeId);
        void Insert(Make make);
        void Update(Make make);
        void Delete(int MakeId);
    }
}
