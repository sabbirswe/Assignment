using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIProject.Shared.Model
{
    public class OrderDetailModel
    {
        public int OrderDetailId { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
        public string ItemName { get; set; }
        public ItemModel Item { get; set; }
        public OrderModel Order { get; set; }
    }
}
