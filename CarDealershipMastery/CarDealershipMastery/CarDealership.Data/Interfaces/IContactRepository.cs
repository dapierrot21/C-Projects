using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Interfaces
{
    public interface IContactRepository
    {
        Contact GetById(int contactId);
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(int contactId);
    }
}
