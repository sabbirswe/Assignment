using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIProject.DAL.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int SupplierId { get; set; }

        [Required]
        [StringLength(50)]
        public string RefID { get; set; }

        [Required]
        [StringLength(50)]
        public string PoNo { get; set; }
       
        public DateTime PoDate { get; set; }

        public DateTime? ExpectedDate { get; set; }

        [StringLength(250)]
        public string Remark { get; set; }


        public Supplier Supplier { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
