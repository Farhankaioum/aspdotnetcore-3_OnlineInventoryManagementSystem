using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Company
{
    public class CompanyEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Company Name")]
        public string Name { get; set; }

        [Display(Name = "Charge Amount(%)")]
        public decimal ChargeAmount { get; set; } = 0;

        [Display(Name = "Vat Charge (%)")]
        public decimal VatCharge { get; set; } = 0;

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Display(Name ="Country Name")]
        public string Country { get; set; }

        [Required]
        public string Message { get; set; }

        public string Currency { get; set; }
    }
}
