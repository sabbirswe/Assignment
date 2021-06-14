using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProject.Shared.Model;

namespace WebAPIProject.BLL.IManager
{
    public interface IItemManager
    {
        Task<List<ItemModel>> GetItemSelectModels();
        
    }
}
