using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIProject.Shared.Model
{
    public class ItemModel
    {
        public int ItemId { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }
    }
}
