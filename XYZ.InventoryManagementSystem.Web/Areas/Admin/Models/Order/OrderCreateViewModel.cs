using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Order
{
    public class OrderCreateViewModel
    {
        [Required(ErrorMessage ="This filed is required.")]
        [Display(Name ="Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This filed is required.")]
        [Display(Name = "Customer Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This filed is required.")]
        [Display(Name = "Customer Phone")]
        public string Phone { get; set; }


        
        public List<XYZ.InventoryManagementSystem.Framework.Product> ProductsName { get; set; }
        [Required(ErrorMessage = "This filed is required.")]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:C}")]
        public int? Qty { get; set; }

        [Required(ErrorMessage = "*")]
        public decimal Rate { get; set; }

        public decimal Amount { get; set; }

        [Display(Name ="Gross Amount")]
        public decimal GrossAmount { get; set; }

        public decimal Vat { get; set; }
        public int VatValue { get; set; }

        public decimal Discount { get; set; }

        [Display(Name ="Net Amount")]
        public decimal NetAmount { get; set; }
    }
}
