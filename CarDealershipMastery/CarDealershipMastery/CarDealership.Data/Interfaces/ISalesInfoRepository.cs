using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface ISalesInfoRepository
    {
        SalesInfo GetById(int salesInfoId);
        void Insert(SalesInfo salesInfo);
        void Update(SalesInfo salesInfo);
        void Delete(int salesInfoId);
    }
}
