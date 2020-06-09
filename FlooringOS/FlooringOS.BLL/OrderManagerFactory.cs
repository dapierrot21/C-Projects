using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOS.Data.TestRepository;
using FlooringOS.Data.ProdRepository;
using FlooringOS.Data;

namespace FlooringOS.BLL
{
     public class OrderManagerFactory
    {
        //Controls which repo to used base on AppSettings value.
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepository(), new TestProductRepository(), new TestTaxRepository());
                case "Prod":
                    return new OrderManager(new ProdOrderRepository(), new ProdProductRepository(), new ProdTaxRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
