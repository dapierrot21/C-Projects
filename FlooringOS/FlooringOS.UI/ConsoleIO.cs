using FlooringOS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlooringOS.UI
{
    public class ConsoleIO
    {
        private static readonly string productline = "{0,-12} {1,3:c} {2,17:c}";
        public static void DisplayOrderDetails(OrderFile order, string date)
        {
            Console.WriteLine("*********************************");
            Console.WriteLine($"[{order.OrderNumber}] | [{date}]");
            if (order.CustomerName.Contains("|"))
            {
                order.CustomerName = order.CustomerName.Replace("|", ",");
            }
            Console.WriteLine($"[{order.CustomerName}]");
            Console.WriteLine($"[{order.State}]");
            Console.WriteLine($"Product: [{order.ProductType}]");
            Console.WriteLine($"Materials: [{order.MaterialCost:c}]");
            Console.WriteLine($"Labor: [{order.LaborCost:c}]");
            Console.WriteLine($"Tax: [{order.Tax:c}]");
            Console.WriteLine($"Total: [{order.Total:c}]");
            Console.WriteLine("*********************************");
        }

        public static void DisplayProductDetails(ProductFile product)
        {
            Console.WriteLine(productline, product.ProductType, product.CostPerSquareFoot, product.LaborCostPerSquareFoot);
        }

        public static string EnterOrderdate(string prompt)
        {
            string orderdatestr;
            DateTime orderdate;
            //Date Format.
            DateTimeFormatInfo info = new DateTimeFormatInfo
            {
                ShortDatePattern = @"MM/dd/yyyy"
            };
            // loop until we return an Yes or No
            while (true)
            {
                Console.Write(prompt);
                orderdatestr = Console.ReadLine();
                //TryParseExact overloads: string, string[], IFormatProvider, DateTimeStyle, DateTime.
                if (DateTime.TryParseExact(orderdatestr, @"MM/dd/yyyy", info, DateTimeStyles.None, out orderdate))
                {
                    break;
                }
                Console.WriteLine("That is not a valid order date.");
            }
            return orderdate.ToShortDateString();
        }

        public static string EnterFutureOrderdate(string prompt)
        {
            string orderdatestr = "";
            while (true)
            {
                orderdatestr = EnterOrderdate(prompt);
                DateTime orderdate = Convert.ToDateTime(orderdatestr);
                if (orderdate.Date > DateTime.Today.Date)
                {
                    break;
                }
                Console.WriteLine("Enter a future order date!");
            }
            return orderdatestr;
        }

        public static string EnterProductType(string prompt, List<ProductFile> productlist, OrderActionChoice orderactiontype)
        {
            Console.WriteLine(productline, "Product Type", "CostPerSquareFoot", "LaborCostPerSquareFoot");
            Console.WriteLine("=====================================================");
            foreach (ProductFile product in productlist)
            {
                DisplayProductDetails(product);
            }
            string producttype = "";
            while (true)
            {
                Console.Write(prompt);
                producttype = Console.ReadLine();
                if (OrderActionChoice.Edit == orderactiontype && producttype == "")
                {
                    break;
                }
                bool exists = productlist.Exists(product => product.ProductType == producttype);
                if (exists)
                {
                    break;
                }
                Console.WriteLine("Invalid ProductType Entered!");
            }
            return producttype;
        }

        public static string EnterState(string prompt, List<TaxFile> taxlist, OrderActionChoice orderActionChoice)
        {
            string stateabbr = "";
            while (true)
            {
                Console.Write(prompt);
                stateabbr = Console.ReadLine();
                if (OrderActionChoice.Edit == orderActionChoice && stateabbr == "")
                {
                    break;
                }
                bool exists = taxlist.Exists(tax => tax.StateAbbr == stateabbr);
                if (exists)
                {
                    break;
                }
                Console.WriteLine("ProductType is not sold in that State. Please enter another state or contact IT!");
            }
            return stateabbr;
        }

        public static string EnterCustomerName(string prompt, OrderActionChoice orderactiontype)
        {
            string customername = "";
            string validchar = "^[a-zA-Z0-9.,]+$";
            while (true)
            {
                Console.Write(prompt);
                customername = Console.ReadLine();
                if (OrderActionChoice.Edit == orderactiontype && customername == "")
                {
                    break;
                }
                //matching input to the valid character format.
                bool validCharFormat = Regex.IsMatch(customername, validchar);
                if (validCharFormat)
                {
                    break;
                }
                Console.WriteLine("Invalid Customer Name Entered. Name should contain contain only the following [a-z][0-9],period,and comma.");
            }
            return customername;
        }

        public static decimal EnterArea(string prompt, OrderActionChoice orderactiontype)
        {
            decimal area = 0.00M;
            while (true)
            {
                Console.Write(prompt);
                string areastr = Console.ReadLine();
                if (OrderActionChoice.Edit == orderactiontype && areastr == "")
                {
                    break;
                }
                if (decimal.TryParse(areastr, out area))
                {
                    if (area >= 100.00M)
                    {
                        break;
                    }
                }
                Console.WriteLine("Incorrect Area entered!");
            }
            return area;
        }

        public static char UserchoiceYesorNo(string prompt)
        {
            char userchoice;
            ConsoleKeyInfo cki;
            // loop until we return an Yes or No
            while (true)
            {
                Console.Write(prompt);
                cki = Console.ReadKey();
                userchoice = cki.KeyChar;
                if (Char.ToUpper(userchoice) == 'Y' || Char.ToUpper(userchoice) == 'N')
                {
                    Console.WriteLine("");
                    break;
                }
                Console.WriteLine("That is not a valid choice. Enter Y or N!");
            }
            return userchoice;
        }
        public static int EnterOrderNumber(string prompt)
        {
            int result;
            string userInput;
            while (true)
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid valid order number/format entered. Order # is an integer!");
            }
        }
    }
}
