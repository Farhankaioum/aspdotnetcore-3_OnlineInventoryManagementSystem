using System.Collections.Generic;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Brand
{
    public class BrandIndexViewModel : AdminBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public List<XYZ.InventoryManagementSystem.Framework.Brand> Brands { get; set; }
    }
}

