using FlooringOS.BLL;
using FlooringOS.Models;
using FlooringOS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            OrderManager manager = OrderManagerFactory.Create();

            string orderdate = ConsoleIO.EnterOrderdate("Enter an order date in mm/dd/yyyy format, example 01/12/2015: ");

            //Enter order date.
            int ordernumber = ConsoleIO.EnterOrderNumber("Enter an order number, example 5 or 10: ");

            //Look up order by date and order number.
            OrderLookupResponse orderlookupresponse = manager.LookupOrder(orderdate, ordernumber);
            //If orderdate and order number exist, add new info.
            if (orderlookupresponse.Success)
            {
                OrderFile order = orderlookupresponse.OrderFile;
                Console.WriteLine("Enter the new order information: ");

                string customername = ConsoleIO.EnterCustomerName($"Enter the Customer Name ({order.CustomerName}): ", OrderActionChoice.Edit);
                //the ternary conditional operator. Decided to use this expression instead of a if/else statement.
                customername = customername == "" ? order.CustomerName : customername;

                TaxListLookupResponse taxeslookupresponse = manager.LookupTaxes();
                string state = ConsoleIO.EnterState($"Enter the State(abbreviated) ({order.State}): ", taxeslookupresponse.taxList, OrderActionChoice.Edit);
                state = state == "" ? order.State : state;

                ProductListLookupResponse productslookupresponse = manager.LookupProducts();
                string producttype = ConsoleIO.EnterProductType($"Enter the Product Type from the above ({order.ProductType}): ", productslookupresponse.productList, OrderActionChoice.Edit);
                producttype = producttype == "" ? order.ProductType : producttype;

                decimal area = ConsoleIO.EnterArea($"Minimum order size is 100 square feet. Enter the area ({order.Area}): ", OrderActionChoice.Edit);
                area = area == 0.00M ? order.Area : area;

                order = manager.CreateOrderInfo(ordernumber, customername, state, producttype, area);
                Console.WriteLine("Below is the updated order Summary: ");
                //Display order details
                ConsoleIO.DisplayOrderDetails(order, orderdate);

                //Verfiy.
                char confirmorder = ConsoleIO.UserchoiceYesorNo("Are you sure you want to update the order? Enter Y or N: ");
                if (char.ToUpper(confirmorder) == 'Y')
                {
                    Response editorder = manager.ProcessOrder(order, orderdate, OrderActionChoice.Edit);
                    if (editorder.Success)
                    {
                        Console.WriteLine("Order updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Order not updated.");
                    }
                }
            }
            else
            {
                Console.WriteLine(orderlookupresponse.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
