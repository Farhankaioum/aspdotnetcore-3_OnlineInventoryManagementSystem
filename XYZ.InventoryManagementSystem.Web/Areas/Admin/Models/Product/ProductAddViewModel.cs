using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using XYZ.InventoryManagementSystem.Framework;
using Color = XYZ.InventoryManagementSystem.Framework.Color;
using Size = XYZ.InventoryManagementSystem.Framework.Size;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Product
{
    public class ProductAddViewModel : AdminBaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Available { get; set; }

        public List<XYZ.InventoryManagementSystem.Framework.Brand> Brands { get; set; }
        [Required]
        public int BrandId { get; set; }

        public List<XYZ.InventoryManagementSystem.Framework.Category> Categories { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public List<Color> Colors { get; set; }
        [Required(ErrorMessage ="At least one Color select")]
        public List<int> ColorIds { get; set; }

        public List<Size> Sizes { get; set; }
        [Required(ErrorMessage = "At least one Size select")]
        public List<int> SizeIds { get; set; }

        public List<Store> Stores { get; set; }
        [Required(ErrorMessage = "At least one Stores select")]
        public List<int> StoreIds { get; set; }

    }
}
