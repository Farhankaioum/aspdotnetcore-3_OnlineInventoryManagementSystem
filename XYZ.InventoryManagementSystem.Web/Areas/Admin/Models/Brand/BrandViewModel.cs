using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Brand
{
    public class BrandViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Product Availability")]
        public bool Status { get; set; }
    }
}
