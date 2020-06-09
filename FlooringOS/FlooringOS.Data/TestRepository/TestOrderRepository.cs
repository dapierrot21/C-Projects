using FlooringOS.Models;
using FlooringOS.Models.Interfaces;
using FlooringOS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Data.TestRepository
{
    public class TestOrderRepository : IOrderRepo
    {

        private List<OrderFile> _orderList = new List<OrderFile>();

        private static Dictionary<string, List<OrderFile>> _orderdictionary = new Dictionary<string, List<OrderFile>>
        {
            { "06/06/2013", new List<OrderFile>
            {
            new OrderFile
            {
                OrderNumber = 1,
                CustomerName = "Shawn",
                State = "KY",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 150.00M,
                CostPerSquareFoot = 9.55M,
                LaborCostPerSquareFoot = 7.75M,
                MaterialCost = 315.00M,
                LaborCost = 479.00M,
                Tax = 91.88M,
                Total = 1060.78M
            },
            new OrderFile
            {
                OrderNumber = 2,
                CustomerName = "Ricky",
                State = "TX",
                TaxRate = 7.90M,
                ProductType = "Carpet",
                Area = 250.00M,
                CostPerSquareFoot = 9.15M,
                LaborCostPerSquareFoot = 5.75M,
                MaterialCost = 17830.00M,
                LaborCost = 1150.00M,
                Tax = 1992.74M,
                Total = 3852.74M
            }
            }
            },
            { "05/05/2020", new List<OrderFile>
            {
            new OrderFile
            {
                OrderNumber = 3,
                CustomerName = "Morty",
                State = "CA",
                TaxRate = 6.25M,
                ProductType = "Wood",
                Area = 900.00M,
                CostPerSquareFoot = 9.15M,
                LaborCostPerSquareFoot = 4.75M,
                MaterialCost = 915.00M,
                LaborCost = 479.00M,
                Tax = 61.98M,
                Total = 1951.88M
            },
            new OrderFile
            {
                OrderNumber = 4,
                CustomerName = "Dave",
                State = "CO",
                TaxRate = 5.25M,
                ProductType = "Carpet",
                Area = 800.00M,
                CostPerSquareFoot = 6.15M,
                LaborCostPerSquareFoot = 5.75M,
                MaterialCost = 1250.00M,
                LaborCost = 1150.00M,
                Tax = 1892.74M,
                Total = 3852.74M
            }
            }
            },
            { "01/01/2030", new List<OrderFile>{} }
         };

        private OrderDateFileResponse MakeFilePath(string orderDate)
        {
            DateTime orderDateOut;
            DateTimeFormatInfo info = new DateTimeFormatInfo
            {
                ShortDatePattern = @"MM/dd/yyyy"
            };
            OrderDateFileResponse orderdatefile = new OrderDateFileResponse();
            if (DateTime.TryParseExact(orderDate, @"MM/dd/yyyy", info, DateTimeStyles.None, out orderDateOut))
            {
                orderdatefile.path = orderDate;
            }
            return orderdatefile;
        }
        private OrderDateFileResponse GetFilePath(string orderdate)
        {
            OrderDateFileResponse orderdatefile = new OrderDateFileResponse();
            if (_orderdictionary.ContainsKey(orderdate))
            {
                orderdatefile.path = orderdate;
            }
            else
            {
                orderdatefile.path = "";
            }
            return orderdatefile;
        }
        public OrderFile LoadOrder(string orderdatepath, int ordernumber)
        {
            OrderFile order = new OrderFile();
            if (_orderdictionary.ContainsKey(orderdatepath))
            {
                order = _orderdictionary[orderdatepath].FirstOrDefault(o => o.OrderNumber == ordernumber);
            }
            return order;
        }
        public List<OrderFile> LoadOrders(string orderdatepath)
        {
            _orderList.Clear();
            if (_orderdictionary.ContainsKey(orderdatepath))
            {
                _orderList = _orderdictionary[orderdatepath];
            }
            return _orderList;
        }
        public OrderFile AddOrderToExistingOrderFile(OrderFile order, string orderdatepath)
        {
            if (_orderdictionary.ContainsKey(orderdatepath))
            {
                _orderdictionary[orderdatepath].Add(order);
            }
            return order;
        }
        public OrderFile AddOrderToNewOrderFile(OrderFile order, string orderdatepath)
        {
            _orderdictionary.Add(orderdatepath, new List<OrderFile> { order });
            return order;
        }

        public OrderFile EditOrder(OrderFile order, string orderdatepath)
        {
            if (_orderdictionary.ContainsKey(orderdatepath))
            {
                var index = _orderdictionary[orderdatepath].FindIndex(o => o.OrderNumber == order.OrderNumber);
                _orderdictionary[orderdatepath][index] = order;
            }
            return order;
        }
        public OrderFile RemoveOrder(OrderFile order, string orderdatepath)
        {
            if (_orderdictionary.ContainsKey(orderdatepath))
            {
                var removeorder = _orderdictionary[orderdatepath].Find(o => o.OrderNumber == order.OrderNumber);
                _orderdictionary[orderdatepath].Remove(removeorder);
            }
            return order;
        }
    }
}
