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
    public class ProdProductRepository : IProductRepo
    {
        private static readonly string productspath = @"C:\Users\dapie\OneDrive\Projects\repoSG\online-net-dapierrot21\m3-summative\FlooringOS\FlooringOS.Data\Products.txt";
        private static List<ProductFile> _productList = new List<ProductFile>();
        public ProductFile LoadProduct(string ProductType)
        {
            ProductFile product = new ProductFile();
            BuildProductListFromFile();
            product = _productList.FirstOrDefault(p => p.ProductType == ProductType);
            return product;
        }

        public List<ProductFile> LoadProducts()
        {
            BuildProductListFromFile();
            return _productList;
        }

        private void BuildProductListFromFile()
        {
            _productList.Clear();
            if (File.Exists(productspath))
            {
                List<string> rows = new List<string>();
                using (StreamReader reader = new StreamReader(productspath))
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
                        ProductFile _product = new ProductFile();
                        _product.ProductType = columns[0];
                        _product.CostPerSquareFoot = Convert.ToDecimal(columns[1]);
                        _product.LaborCostPerSquareFoot = Convert.ToDecimal(columns[2]);
                        _productList.Add(_product);
                    }
                }
            }
        }
    }
}
