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
    public class SupplierManager : ISupplierManager
    {
        private readonly IMapper _mapper;
        private readonly IApplicationRepository<Supplier> _supplierRepository;
        public SupplierManager(IMapper mapper, IApplicationRepository<Supplier> supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<List<SupplierModel>> GetSupplierSelectModels()
        {
            try
            {
                var suppliers = await _supplierRepository.GetAllAsync();
                return _mapper.Map<List<SupplierModel>>(suppliers);
            }
            catch(Exception e)
            {

            }
            return null;
        }

    }
}
