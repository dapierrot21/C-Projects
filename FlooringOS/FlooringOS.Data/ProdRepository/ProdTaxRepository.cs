using FlooringOS.Models;
using FlooringOS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Data.ProdRepository
{
    public class ProdTaxRepository : ITaxRepo
    {
        private static readonly string taxespath = @"C:\Users\dapie\OneDrive\Projects\repoSG\online-net-dapierrot21\m3-summative\FlooringOS\FlooringOS.Data\Taxes.txt";
        private static readonly List<TaxFile> _taxList = new List<TaxFile>();

        public TaxFile LoadTax(string StateAbbreviation)
        {
            TaxFile tax = new TaxFile();
            BuildTaxListFromFile();
            tax = _taxList.FirstOrDefault(a => a.StateAbbr == StateAbbreviation);
            return tax;
        }

        public List<TaxFile> LoadTaxes()
        {
            BuildTaxListFromFile();
            return _taxList;
        }

        private void BuildTaxListFromFile()
        {
            _taxList.Clear();
            if (File.Exists(taxespath))
            {
                List<string> rows = new List<string>();
                using (StreamReader reader = new StreamReader(taxespath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        rows.Add(line);
                    }
                }
                if (rows.Count > 0)
                {
                    for (int i = 1; i < rows.Count; i++)
                    {
                        string[] columns = rows[i].Split(',');
                        TaxFile tax = new TaxFile();
                        tax.StateAbbr = columns[0];
                        tax.StateName = columns[1];
                        tax.TaxRate = Convert.ToDecimal(columns[2]);
                        _taxList.Add(tax);
                    }
                }
            }
        }
    }
}
