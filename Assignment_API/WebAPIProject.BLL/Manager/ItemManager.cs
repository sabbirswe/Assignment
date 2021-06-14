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
    public class ItemManager : IItemManager
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRepository<Item> _itemRepository;
        public ItemManager(IMapper mapper, IApplicationRepository<Item> itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<List<ItemModel>> GetItemSelectModels()
        {
            try
            {
                var items = await _itemRepository.GetAllAsync();
                return _mapper.Map<List<ItemModel>>(items);
            }
            catch (Exception e)
            {

            }
            return null;
        }

    }
}
