using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProject.Shared.Model;

namespace WebAPIProject.BLL.IManager
{
    public interface IOrderManager
    {
        List<OrderModel> GetOrders(int ps, int pn, string qs, out int total);
        Task<OrderModel> GetOrder(int id);
        Task<OrderModel> GetOrderReport(int id);
        Task<OrderModel> SaveOrder(OrderSaveModel model);
        Task<OrderModel> UpdateOrder(OrderSaveModel model);
        Task<OrderModel> DeleteOrder(int id);

    }
}
