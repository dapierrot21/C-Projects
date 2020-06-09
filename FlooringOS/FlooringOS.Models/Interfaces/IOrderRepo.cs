using FlooringOS.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOS.Models.Interfaces
{
    public interface IOrderRepo
    {
        OrderFile LoadOrder(string orderDatePath, int orderNumber);
        List<OrderFile> LoadOrders(string orderDatePath);
        OrderFile AddOrderToExistingOrderFile(OrderFile order, string orderDatePath);
        OrderFile AddOrderToNewOrderFile(OrderFile order, string orderDatePath);
        OrderFile EditOrder(OrderFile order, string orderDatePath);
        OrderFile RemoveOrder(OrderFile order, string orderDatepPath);
    }
}
