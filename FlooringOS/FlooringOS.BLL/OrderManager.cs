using FlooringOS.Models;
using FlooringOS.Models.Interfaces;
using FlooringOS.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringOS.BLL
{
    public class OrderManager
    {
        private IOrderRepo _orderRepository;
        private IProductRepo _productRepository;
        private ITaxRepo _taxRepository;

        //Constructor: must provide Repositories.
        public OrderManager(IOrderRepo orderRepository, IProductRepo productRepository, ITaxRepo taxRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _taxRepository = taxRepository;
        }

        public OrderLookupResponse LookupOrder(string orderDate, int orderNumber)
        {
            //Create a OrderLookupResponse object.
            OrderLookupResponse orderLookup = new OrderLookupResponse();

            OrderDateFileResponse orderDateFile = _orderRepository.GetFilePath(orderDate);

            //Checks to see if file exists.
            if(string.IsNullOrEmpty(orderDateFile.path))
            {
                orderLookup.Success = false;
                orderLookup.Message = $"Could not find Order File: {orderDate}";
            }
            else
            {
                //Load Order file to the response object.
                orderLookup.OrderFile = _orderRepository.LoadOrder(orderDateFile.path, orderNumber);

                //If not orders on the file.
                if (orderLookup.OrderFile == null)
                {
                    orderLookup.Success = false;
                    orderLookup.Message = $"Order Date: {orderDate} and Order Number: {orderNumber} was not found.";
                }
                else
                {
                    orderLookup.Success = true;

                    //If Customer/Business Name contain special characters.
                    if (orderLookup.OrderFile.CustomerName.Contains("|"))
                    {
                        //Replace with comma.
                        orderLookup.OrderFile.CustomerName = orderLookup.OrderFile.CustomerName.Replace("|", ",");
                    }
                }
            }
            //Return the order response object.
            return orderLookup;
        }

        //Loads orders from a file onto a list.
        public OrderListLookupResponse LoadOrdersToList(string orderDate)
        {
            //Instantiate a Order list response object.
            OrderListLookupResponse ordersLookup = new OrderListLookupResponse();

            OrderDateFileResponse orderDateFile = _orderRepository.GetFilePath(orderDate);

            //If the file path doesn't exists.
            if (string.IsNullOrEmpty(orderDateFile.path))
            {
                ordersLookup.Success = false;
                ordersLookup.Message = $"Could not found file from Order date:  {orderDate}.";
            }
            else
            {
                //Load Orders to the List.
                ordersLookup.orderList = _orderRepository.LoadOrders(orderDateFile.path);

                //Checks to see if the orderlist is not empty. 
                if (ordersLookup.orderList.Count > 0)
                {
                    ordersLookup.Success = true;
                }
                else
                {
                    ordersLookup.Success = false;
                    ordersLookup.Message = $"There's no orders with {orderDate}.";
                }
            }
            //Return the List<OrderFile> response object.
            return ordersLookup;
        }

        //Process Order: Add, Edit, Remove.
        public OrderProcessResponse ProcessOrder(OrderFile order, string orderDate, OrderActionChoice orderActionChoice)
        {
            //Checks Action choice.
            if(orderActionChoice == OrderActionChoice.Add || orderActionChoice == OrderActionChoice.Edit)
            {
                //If Customer/Business name contain a special charatcer.
                if (order.CustomerName.Contains("|"))
                {
                    //Replace it.
                    order.CustomerName = order.CustomerName.Replace("|", ",");
                }
            }

            //Instantiate a Order process object.
            OrderProcessResponse processOrder = new OrderProcessResponse();

            OrderDateFileResponse orderDateFile = _orderRepository.GetFilePath(orderDate);

            //Checks if file path is empty.
            if (string.IsNullOrEmpty(orderDateFile.path))
            {
                processOrder.Success = false;
                processOrder.Message = $"Could not find file from Order date:  {orderDate}.";
            }
            else
            {
                switch (orderActionChoice)
                {
                    case OrderActionChoice.Add:
                        processOrder.order = _orderRepository.AddOrderToExistingOrderFile(order, orderDateFile.path);
                        break;
                    case OrderActionChoice.Edit:
                        processOrder.order = _orderRepository.EditOrder(order, orderDateFile.path);
                        break;
                    case OrderActionChoice.Remove:
                        processOrder.order = _orderRepository.RemoveOrder(order, orderDateFile.path);
                        break;
                    default:
                        throw new Exception("Invalid Choice!");
                }

                //If the process order is empty.
                if (processOrder.order == null)
                {
                    processOrder.Success = false;
                    processOrder.Message = "Could not save order to file.";
                }
                else
                {
                    processOrder.Success = true;
                    processOrder.Message = "Order was saved to file.";
                }
            }

            //if choice is add and file path for order date is empty.
            if (orderActionChoice == OrderActionChoice.Add && string.IsNullOrEmpty(orderDateFile.path))
            {
                //Make a new order date file path.
                OrderDateFileResponse newOrderDateFile = _orderRepository.MakeFilePath(orderDate);

                //if new file path is empty after being created.
                if (string.IsNullOrEmpty(newOrderDateFile.path))
                {
                    processOrder.Success = false;
                    processOrder.Message = $"Could not create a new order date file for Order date: {orderDate}.";
                }
                else
                {
                    processOrder.order = _orderRepository.AddOrderToNewOrderFile(order, newOrderDateFile.path);

                    //If process order is empty.
                    if (processOrder.order == null)
                    {
                        processOrder.Success = false;
                        processOrder.Message = "Could not save new order to new order file.";
                    }
                    else
                    {
                        processOrder.Success = true;
                        processOrder.Message = "New order was saved to new file.";
                    }
                }
            }
            return processOrder;
        }

        public ProductListLookupResponse LookupProducts()
        {
            //Instantiate a List<ProductFile> response object.
            ProductListLookupResponse productslookupresponse = new ProductListLookupResponse();

            //Loads those products to a list.
            productslookupresponse.productList = _productRepository.LoadProducts();

            //Checks if the list contains any products.
            if (productslookupresponse.productList.Count > 0)
            {
                productslookupresponse.Success = true;
            }
            else
            {
                productslookupresponse.Success = false;
                productslookupresponse.Message = $"Could not found Products";
            }

            // Return response object.
            return productslookupresponse;
        }

        public TaxListLookupResponse LookupTaxes()
        {
            TaxListLookupResponse taxLookup = new TaxListLookupResponse();
            taxLookup.taxList = _taxRepository.LoadTaxes();

            //Checks if the list contains any Tax info.
            if (taxLookup.taxList.Count > 0)
            {
                taxLookup.Success = true;
            }
            else
            {
                taxLookup.Success = false;
                taxLookup.Message = $"Could not find tax info.";
            }

            // return response object.
            return taxLookup;
        }

        public int CreateOrderNumber(string orderdate)
        {
            int orderNumber = 0;
            OrderListLookupResponse ordersLookup = LoadOrdersToList(orderdate);
            if (ordersLookup.Success)
            {
                var orders = ordersLookup.orderList.OrderByDescending(o => o.OrderNumber).Take(1).ToList();
                orderNumber = orders.First().OrderNumber + 1;
            }
            else
            {
                orderNumber = 1;
            }
            return orderNumber;
        }

        public OrderFile CreateOrderInfo(int ordernumber, string customername, string state, string producttype, decimal area)
        {
            OrderFile order = new OrderFile();
            TaxFile tax = _taxRepository.LoadTax(state);
            ProductFile product = _productRepository.LoadProduct(producttype);
            order.OrderNumber = ordernumber;
            order.CustomerName = customername;
            order.State = state;
            order.ProductType = producttype;
            order.Area = area;
            order.TaxRate = tax.TaxRate;
            order.CostPerSquareFoot = product.CostPerSquareFoot;
            order.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
            order.MaterialCost = (order.Area * order.CostPerSquareFoot);
            order.LaborCost = (order.Area * order.LaborCostPerSquareFoot);
            order.Tax = ((order.MaterialCost + order.LaborCost) * (order.TaxRate / 100));
            order.Total = (order.MaterialCost + order.LaborCost + order.Tax);
            return order;
        }
    }
}
