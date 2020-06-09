using FlooringOS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Models.Interfaces
{
    public interface ITaxRepo
    {
        TaxFile LoadTax(string StateAbbrev);
        List<TaxFile> LoadTaxes();
    }
}
