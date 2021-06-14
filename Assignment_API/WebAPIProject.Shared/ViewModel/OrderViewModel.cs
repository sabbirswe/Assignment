using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIProject.Shared.Model
{
    public class OrderViewModel 
    {
        public List<ItemModel> Items { get; set; }

        public List<SupplierModel> Suppliers { get; set; }

        public OrderModel Order { get; set; }

    }
}
