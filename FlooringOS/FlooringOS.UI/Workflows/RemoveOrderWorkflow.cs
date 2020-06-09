﻿using FlooringOS.BLL;
using FlooringOS.Models;
using FlooringOS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            OrderManager manager = OrderManagerFactory.Create();

            string orderdate = ConsoleIO.EnterOrderdate("Enter an order date in mm/dd/yyyy format, example 01/12/2015: ");
            int ordernumber = ConsoleIO.EnterOrderNumber("Enter an order number, example 5 or 10: ");

            OrderLookupResponse orderlookupresponse = manager.LookupOrder(orderdate, ordernumber);
            if (orderlookupresponse.Success)
            {
                OrderFile order = orderlookupresponse.OrderFile;
                Console.WriteLine($"Below is the order Summary for {ordernumber}: ");
                ConsoleIO.DisplayOrderDetails(order, orderdate);

                char confirmOrder = ConsoleIO.UserchoiceYesorNo("Are you sure you want to remove the order? Enter Y or N: ");
                if (char.ToUpper(confirmOrder) == 'Y')
                {
                    Response removeorder = manager.ProcessOrder(order, orderdate, OrderActionChoice.Remove);

                    if (removeorder.Success)
                    {
                        Console.WriteLine("Order removed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Error in removing order. Please contact IT!");
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
