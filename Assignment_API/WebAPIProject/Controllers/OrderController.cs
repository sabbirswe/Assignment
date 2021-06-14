using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.BLL.IManager;
using WebAPIProject.Shared;
using WebAPIProject.Shared.Model;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IOrderDetailManager _orderDetailManager;
        private readonly IItemManager _itemManager;
        private readonly ISupplierManager _supplierManager;

        public OrderController(IOrderManager orderManager,IOrderDetailManager orderDetailManager, IItemManager itemManager, ISupplierManager supplierManager)
        {
            _orderManager = orderManager;
            _orderDetailManager = orderDetailManager;
            _itemManager = itemManager;
            _supplierManager = supplierManager;
        }

        [HttpGet]
        [Route("get-orders")]
        public async Task<IActionResult> GetOrders(int ps, int pn, string qs)
        {
            int total = 0;
            var response = _orderManager.GetOrders(ps,pn,qs,out total);
            return Ok(new ResponseMessage<List<OrderModel>>()
            {
                Result = response,
                Total = total,
               
            });
        }



        [HttpGet]
        [Route("get-order/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var viewModel = new OrderViewModel();
            viewModel.Order = await _orderManager.GetOrder(id);
            viewModel.Order.OrderDetails = await _orderDetailManager.GetOrderDetails(id);
            viewModel.Items = await _itemManager.GetItemSelectModels();
            viewModel.Suppliers = await _supplierManager.GetSupplierSelectModels();
            return Ok(viewModel);
        }

        [HttpGet]
        [Route("get-order-report/{id}")]
        public async Task<IActionResult> GetOrderReport(int id)
        {
            var response= await _orderManager.GetOrderReport(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("save-order")]
        public async Task<IActionResult> SaveOrder(OrderSaveModel model)
        {
            var response = await _orderManager.SaveOrder(model);
            return Ok(response);
        }


        [HttpPut]
        [Route("update-Order")]
        public async Task<IActionResult> UpdateOrder(OrderSaveModel model)
        {
            var response = await _orderManager.UpdateOrder(model);
            return Ok(response);
        }



        [HttpDelete]
        [Route("delete-order/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await _orderManager.DeleteOrder(id);
            return Ok(response);
        }
    }
}
