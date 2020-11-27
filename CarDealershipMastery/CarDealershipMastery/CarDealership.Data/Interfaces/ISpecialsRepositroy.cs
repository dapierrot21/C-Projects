using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface ISpecialsRepositroy
    {
        Specials GetById(int specialsId);
        void Insert(Specials specials);
        void Update(Specials specials);
        void Delete(int specialsId);
        IEnumerable<Specials> GetSpecials();
    }
}
