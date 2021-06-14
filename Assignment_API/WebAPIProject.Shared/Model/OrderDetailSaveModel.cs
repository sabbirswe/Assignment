using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIProject.Shared.Model
{
    public class OrderDetailSaveModel
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
    }
}
