using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProject.DAL;
using WebAPIProject.DAL.Model;
using WebAPIProject.Shared.Model;

namespace WebAPIProject.Shared
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {

            CreateMap<Supplier, SupplierModel>();
            CreateMap<SupplierModel, Supplier>();

            CreateMap<Item, ItemModel>();
            CreateMap<ItemModel, Item>();

            CreateMap<Order, OrderSaveModel>();
            CreateMap<OrderSaveModel, Order>();

            CreateMap<OrderDetail, OrderDetailSaveModel>();
            CreateMap<OrderDetailSaveModel, OrderDetail>();


            CreateMap<Order, OrderModel>()
            .ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.Supplier));
            CreateMap<OrderModel, Order>()
            .ForMember(dest => dest.Supplier, act => act.MapFrom(src => src.Supplier));

            CreateMap<OrderDetail, OrderDetailModel>()
                .ForMember(dest => dest.Item, act => act.MapFrom(src => src.Item))
                .ForMember(dest => dest.Order, act => act.MapFrom(src => src.Order));
            CreateMap<OrderDetailModel, OrderDetail>()
            .ForMember(dest => dest.Item, act => act.MapFrom(src => src.Item))
                .ForMember(dest => dest.Order, act => act.MapFrom(src => src.Order));


        }
    }
}
