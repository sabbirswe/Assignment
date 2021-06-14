using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProject.DAL.IRepository;

namespace WebAPIProject.DAL.Repository
{
    public class ApplicationRepository<T> : Repository<ApplicationDbContext, T>, IApplicationRepository<T>
         where T : class
    {

        public ApplicationRepository(ApplicationDbContext context) : base(context)
        {

        }


    }
}
