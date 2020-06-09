using FlooringOS.Models.Responses;
using FlooringOS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOS.Models;

namespace FlooringOS.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            
            OrderManager manager = OrderManagerFactory.Create();

            //Enter future order date for file.
            Console.WriteLine("Enter the new order information: ");
            string orderdate = ConsoleIO.EnterFutureOrderdate("Enter a future order date in mm/dd/yyyy format, example 01/12/2020: ");

            //Enter Customer name.
            string customername = ConsoleIO.EnterCustomerName("Enter the Customer Name: ", OrderActionChoice.Add);
            
            //Enter State for tax info.
            //Load Tax info into a list.
            TaxListLookupResponse taxeslookupresponse = manager.LookupTaxes();
            string state = ConsoleIO.EnterState("Enter the State(abbreviated form): ", taxeslookupresponse.taxList, OrderActionChoice.Add);

            //Enter Product info.
            //Load Product from file to a list.
            ProductListLookupResponse productslookupresponse = manager.LookupProducts();
            string producttype = ConsoleIO.EnterProductType("Enter the Product Type from the above: ", productslookupresponse.productList, OrderActionChoice.Add);
            decimal area = ConsoleIO.EnterArea("Minimum order size is 100 square feet. Enter the area: ", OrderActionChoice.Add);

            //Generate order number for oder.
            int ordernumber = manager.CreateOrderNumber(orderdate);

            //Create the order.
            OrderFile order = manager.CreateOrderInfo(ordernumber, customername, state, producttype, area);
            Console.WriteLine("Below is the New order Summary that you just entered: ");

            //Display Order details.
            ConsoleIO.DisplayOrderDetails(order, orderdate);

            //Verfiy.
            char confirmorder = ConsoleIO.UserchoiceYesorNo("Are you sure you want to place the order? Enter Y or N: ");

            if (char.ToUpper(confirmorder) == 'Y')
            {
                Response addorder = manager.ProcessOrder(order, orderdate, OrderActionChoice.Add);

                if (addorder.Success)
                {
                    Console.WriteLine("New Order saved successfully!");
                }
                else
                {
                    Console.WriteLine("New Order not saved. Please try again or contact IT!");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
