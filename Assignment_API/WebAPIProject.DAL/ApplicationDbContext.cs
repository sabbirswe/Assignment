using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProject.DAL.Model;

namespace WebAPIProject.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {

        }

        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
