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
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {

            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an Order(s)");
            Console.WriteLine("--------------------------");
            string orderdate = ConsoleIO.EnterOrderdate("Enter an order date in mm/dd/yyyy format, example 01/20/2008: ");

            //Load orders onto a list from order date.
            OrderListLookupResponse orderslookupresponse = manager.LoadOrdersToList(orderdate);

            if (orderslookupresponse.Success)
            {
                foreach (OrderFile order in orderslookupresponse.orderList)
                {
                    //Display each order on that date.
                    ConsoleIO.DisplayOrderDetails(order, orderdate);
                }
            }
            else
            {
                Console.WriteLine(orderslookupresponse.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
