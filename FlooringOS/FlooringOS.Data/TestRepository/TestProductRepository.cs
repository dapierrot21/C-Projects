using FlooringOS.Models;
using FlooringOS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Data.TestRepository
{
    public class TestProductRepository : IProductRepo
    {
        private static List<ProductFile> _productList = new List<ProductFile>
        {
            new ProductFile
            {
                ProductType  = "Wood",
                CostPerSquareFoot  = 5.15M,
                LaborCostPerSquareFoot  = 4.75M
            },
            new ProductFile
            {
                ProductType  = "Tile",
                CostPerSquareFoot  = 3.5M,
                LaborCostPerSquareFoot  = 4.15M
            },
            new ProductFile
            {
                ProductType  = "Carpet",
                CostPerSquareFoot  = 2.25M,
                LaborCostPerSquareFoot  = 2.10M
            }
         };
        public ProductFile LoadProduct(string ProductType)
        {
            ProductFile product = new ProductFile();
            product = _productList.FirstOrDefault(p => p.ProductType == ProductType);
            return product;
        }
        public List<ProductFile> LoadProducts()
        {
            return _productList;
        }
    }
}
