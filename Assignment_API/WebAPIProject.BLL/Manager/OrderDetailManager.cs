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
    public class OrderDetailManager : IOrderDetailManager
    {

        private readonly IApplicationRepository<OrderDetail> _orderDetailRepository;
        private readonly IMapper _mapper;
        public OrderDetailManager(IMapper mapper,IApplicationRepository<OrderDetail> orderDetailRepository)
        {
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetailModel>> GetOrderDetails(int orderId)
        {
            var OrderList =  _orderDetailRepository.FilterWithInclude(x => x.OrderId==orderId, "Item");
            
            return _mapper.Map<List<OrderDetailModel>>(OrderList);
        }

    }
}
