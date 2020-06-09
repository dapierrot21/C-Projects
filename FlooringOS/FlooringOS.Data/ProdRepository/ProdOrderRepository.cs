using FlooringOS.Models;
using FlooringOS.Models.Interfaces;
using FlooringOS.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Data
{
    public class ProdOrderRepository : IOrderRepo
    {
        //OrderFile Format.
        private static string _orderDirPath = @"C:\Users\dapie\OneDrive\Projects\repoSG\online-net-dapierrot21\m3-summative\FlooringOS\Orders";
        private static string _orderFileBeginString = "Orders_";
        private static string _orderFileYear = "";
        private static string _orderFileEndString = ".txt";

        //OrderFile Header.
        private static string _orderFileHeader = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";
        private static List<OrderFile> _orderList = new List<OrderFile>();
        string comma = ",";

        private OrderDateFileResponse MakeFilePath(string orderDate)
        {
            
            OrderDateFileResponse orderdatefile = new OrderDateFileResponse();
            orderDate = orderDate.Replace("/", "");
            _orderFileYear = orderDate;
            var ordersFileSearch = (_orderFileBeginString + _orderFileYear + _orderFileEndString);
            orderdatefile.path = _orderDirPath + @"\" + ordersFileSearch;
            return orderdatefile;
        }

        private OrderDateFileResponse GetFilePath(string orderDate)
        {
            OrderDateFileResponse orderdatefile = new OrderDateFileResponse();
            orderDate = orderDate.Replace("/", "");
            _orderFileYear = orderDate;
            var ordersfilesearch = (_orderFileBeginString + _orderFileYear + _orderFileEndString);
            //Grabbing file from Orders folder.
            string[] filepath = Directory.GetFiles(_orderDirPath, ordersfilesearch);

            if (filepath.Length > 0)
            {
                orderdatefile.path = filepath[0];
            }
            return orderdatefile;
        }

        public OrderFile LoadOrder(string orderDatePath, int orderNumber)
        {
            OrderFile order = new OrderFile();
            LoadOrders(orderDatePath);
            order = _orderList.FirstOrDefault(o => o.OrderNumber == orderNumber);
            return order;
        }


        public List<OrderFile> LoadOrders(string orderDatePath)
        {
            BuildOrderListFromFile(orderDatePath);
            return _orderList;
        }

        public OrderFile AddOrderToExistingOrderFile(OrderFile order, string orderDatePath)
        {
            using (StreamWriter writer = File.AppendText(orderDatePath))
            {
                writer.WriteLine(order.OrderNumber + comma + order.CustomerName + comma + order.State + comma + order.TaxRate
                        + comma + order.ProductType + comma + order.Area + comma + order.CostPerSquareFoot + comma +
                        order.LaborCostPerSquareFoot + comma + order.MaterialCost + comma + order.LaborCost + comma +
                        order.Tax + comma + order.Total);
            }
            return order;
        }

        public OrderFile AddOrderToNewOrderFile(OrderFile order, string orderDatePath)
        {
            using (StreamWriter writer = new StreamWriter(orderDatePath))
            {
                writer.WriteLine(_orderFileHeader);
                writer.WriteLine(order.OrderNumber + comma + order.CustomerName + comma + order.State + comma + order.TaxRate
                        + comma + order.ProductType + comma + order.Area + comma + order.CostPerSquareFoot + comma +
                        order.LaborCostPerSquareFoot + comma + order.MaterialCost + comma + order.LaborCost + comma +
                        order.Tax + comma + order.Total);
            }
            return order;
        }

        public OrderFile EditOrder(OrderFile order, string orderDatePath)
        {
            BuildOrderListFromFile(orderDatePath);
            var index = _orderList.FindIndex(o => o.OrderNumber == order.OrderNumber);
            _orderList[index] = order;
            WriteListToOrderFile(_orderList, orderDatePath);
            return order;
        }

        public OrderFile RemoveOrder(OrderFile order, string orderDatePath)
        {
            BuildOrderListFromFile(orderDatePath);
            var removeorder = _orderList.Find(o => o.OrderNumber == order.OrderNumber);
            _orderList.Remove(removeorder);
            WriteListToOrderFile(_orderList, orderDatePath);
            return order;
        }

        public void WriteListToOrderFile(List<OrderFile> orderlist, string orderdatepath)
        {
            using (StreamWriter writer = new StreamWriter(orderdatepath))
            {
                writer.WriteLine(_orderFileHeader);
                foreach (var order in orderlist)
                {
                    writer.WriteLine(order.OrderNumber + comma + order.CustomerName + comma + order.State + comma + order.TaxRate
                        + comma + order.ProductType + comma + order.Area + comma + order.CostPerSquareFoot + comma +
                        order.LaborCostPerSquareFoot + comma + order.MaterialCost + comma + order.LaborCost + comma +
                        order.Tax + comma + order.Total);
                }
            }
        }
        private void BuildOrderListFromFile(string orderDatePath)
        {
            _orderList.Clear();
            if (File.Exists(orderDatePath))
            {
                List<string> rows = new List<string>();
                using (StreamReader reader = new StreamReader(orderDatePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        rows.Add(line);
                    }
                }
                if (rows.Count > 1)
                {
                    _orderFileHeader = rows[0];
                    for (int i = 1; i < rows.Count; i++)
                    {
                        string[] columns = rows[i].Split(',');
                        OrderFile _order = new OrderFile
                        {
                            OrderNumber = Convert.ToInt32(columns[0]),
                            CustomerName = columns[1],
                            State = columns[2],
                            TaxRate = Convert.ToDecimal(columns[3]),
                            ProductType = columns[4],
                            Area = Convert.ToDecimal(columns[5]),
                            CostPerSquareFoot = Convert.ToDecimal(columns[6]),
                            LaborCostPerSquareFoot = Convert.ToDecimal(columns[7]),
                            MaterialCost = Convert.ToDecimal(columns[8]),
                            LaborCost = Convert.ToDecimal(columns[9]),
                            Tax = Convert.ToDecimal(columns[10]),
                            Total = Convert.ToDecimal(columns[11])
                        };
                        _orderList.Add(_order);
                    }
                }
            }
        }
    }
}
