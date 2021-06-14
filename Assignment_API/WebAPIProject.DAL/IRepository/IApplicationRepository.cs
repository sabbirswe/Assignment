using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIProject.DAL.IRepository
{
    public interface IApplicationRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        
    }
}
