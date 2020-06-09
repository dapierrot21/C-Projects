using FlooringOS.Models;
using FlooringOS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Data.TestRepository
{
    public class TestTaxRepository : ITaxRepo
    {
        private static List<TaxFile> _taxList = new List<TaxFile>
        {
            new TaxFile
            {
                StateAbbr   = "MI",
                StateName   = "Michigan",
                TaxRate   = 5.75M
            },
            new TaxFile
            {
                StateAbbr  = "OH",
                StateName   = "Ohio",
                TaxRate   = 6.25M
            },
            new TaxFile
            {
                StateAbbr   = "IN",
                StateName   = "Indiana",
                TaxRate   = 6.00M
            }
         };
        public TaxFile LoadTax(string StateAbbreviation)
        {
            TaxFile tax = new TaxFile();
            tax = _taxList.FirstOrDefault(a => a.StateAbbr == StateAbbreviation);
            return tax;
        }
        public List<TaxFile> LoadTaxes()
        {
            return _taxList;
        }
    }
}
