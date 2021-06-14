using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProject.BLL.IManager;
using WebAPIProject.DAL;
using WebAPIProject.DAL.IRepository;
using WebAPIProject.DAL.Model;
using WebAPIProject.Shared.Model;

namespace WebAPIProject.BLL.Manager
{
    public class OrderManager : IOrderManager
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRepository<Order> _orderRepository;
        private readonly IApplicationRepository<OrderDetail> _orderDetailRepository;
        public OrderManager(IMapper mapper, IApplicationRepository<Order> orderRepository, IApplicationRepository<OrderDetail> orderDetailRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        public  List<OrderModel> GetOrders(int ps, int pn, string qs, out int total)
        {

            var orderList =   _orderRepository.FilterWithInclude(x=>x.OrderId>0 && (x.RefID.Contains(qs) || x.Supplier.SupplierName.Contains(qs) || x.PoNo.Contains(qs) || String.IsNullOrEmpty(qs)), "Supplier");
            total = orderList.Count();
            orderList = orderList.Skip((pn - 1) * ps).Take(ps);
            return _mapper.Map<List<OrderModel>>(orderList); 

        }

        public async Task<OrderModel> GetOrder(int id)
        {
            try
            {
                var orderinfo =  _orderRepository.FinedOneInclude(x => x.OrderId == id,"Supplier");

                if (orderinfo != null)
                {
                    var info = _mapper.Map<OrderModel>(orderinfo);
                    info.ResponseCode = "2007";
                    info.ResponseMessage = "Data Found";
                    return info;

                }
                string refNo = "";
                var orderList = await _orderRepository.FilterAsync(x=>x.OrderId>0);
                int count = orderList.OrderByDescending(x=>x.OrderId).Select(x=>x.OrderId).FirstOrDefault();
                if (count < 10)
                    refNo = "00" + (count + 1);
                else if (count < 100)
                {
                    refNo = "0" + (count + 1);
                }
                else 
                {
                    refNo = (count + 1).ToString();
                }
                return new OrderModel {RefID=refNo, ResponseCode = "2004", ResponseMessage = "Not Found" };
            }
            catch (Exception e)
            {
                return new OrderModel { ResponseCode = "2005", ResponseMessage = e.Message };
            }
        }


        public async Task<OrderModel> GetOrderReport(int id)
        {
            try
            {
                var orderinfo = _orderRepository.FinedOneInclude(x => x.OrderId == id, "Supplier");

                if (orderinfo != null)
                {
                   
                    var info = _mapper.Map<OrderModel>(orderinfo);
                    var OrderList = _orderDetailRepository.FilterWithInclude(x => x.OrderId == orderinfo.OrderId, "Item");
                    info.OrderDetails = _mapper.Map<List<OrderDetailModel>>(OrderList);
                    info.ResponseCode = "2007";
                    info.ResponseMessage = "Data Found";
                    return info;

                }
                return new OrderModel {  ResponseCode = "2004", ResponseMessage = "Not Found" };
            }
            catch (Exception e)
            {
                return new OrderModel { ResponseCode = "2005", ResponseMessage = e.Message };
            }
        }


        public async Task<OrderModel> SaveOrder(OrderSaveModel model)
        {
            try
            {
                if (model != null)
                {

                    await _orderRepository.SaveAsync(_mapper.Map<Order>(model));                    
                    return new OrderModel { ResponseCode = "2000", ResponseMessage = "Saved Successfully." };

                }
                return new OrderModel { ResponseCode = "2008", ResponseMessage = "Bad Request" };
            }
            catch (Exception e)
            {
                return new OrderModel { ResponseCode = "2005", ResponseMessage = e.Message };
            }

        }


        public async Task<OrderModel> UpdateOrder(OrderSaveModel model)
        {
            try
            {
                if (model != null)
                {
                    var orderInfo = await _orderRepository.FindOneAsync(x=>x.OrderId==model.OrderId);
                    if (orderInfo != null)
                    {
                        var preOrderDetails= await _orderDetailRepository.FilterAsync(x => x.OrderId == orderInfo.OrderId);
                        _orderDetailRepository.RemoveRange(preOrderDetails);
                        orderInfo.RefID = model.RefID;
                        orderInfo.PoNo = model.PoNo;
                        orderInfo.PoDate = model.PoDate;
                        orderInfo.ExpectedDate = model.ExpectedDate;
                        orderInfo.SupplierId = model.SupplierId;
                        orderInfo.Remark = model.Remark;
                        orderInfo.OrderDetails = _mapper.Map<List<OrderDetail>>(model.OrderDetails);
                        await _orderRepository.SaveAsync(orderInfo);

                        return new OrderModel { ResponseCode = "2001", ResponseMessage = "Saved Successfully." };

                    }
                    return new OrderModel { ResponseCode = "2004", ResponseMessage = "Not Found" };
                }

                return new OrderModel { ResponseCode = "2008", ResponseMessage = "Bad Request" };

            }
            catch (Exception e)
            {
                return new OrderModel { ResponseCode = "2005", ResponseMessage = e.Message };
            }

        }




        public async Task<OrderModel> DeleteOrder(int id)
        {
            try
            {
                var orderinfo = await _orderRepository.FindOneAsync(x => x.OrderId == id);
                if (orderinfo != null)
                {
                    var preOrderDetails = await _orderDetailRepository.FilterAsync(x => x.OrderId == orderinfo.OrderId);
                    _orderDetailRepository.RemoveRange(preOrderDetails);
                    await _orderRepository.DeleteAsync(orderinfo);
                   return new OrderModel { ResponseCode = "2003", ResponseMessage = "Deleted Successfully" };
                }
                return new OrderModel { ResponseCode = "2004", ResponseMessage = "Not Found" };
            }
            catch (Exception e)
            {
                return new OrderModel { ResponseCode = "2005", ResponseMessage = e.Message };
            }
        }



    }
}
