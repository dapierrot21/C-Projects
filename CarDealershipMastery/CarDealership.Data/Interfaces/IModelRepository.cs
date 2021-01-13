using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IModelRepository
    {
        Model GetById(int modelId);
        void Insert(Model model);
        void Update(Model model);
        void Delete(int modelId);
    }
}
