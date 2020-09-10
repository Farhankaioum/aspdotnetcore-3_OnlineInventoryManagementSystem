using System.Collections.Generic;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Product
{
    public class ProductIndexViewModel : AdminBaseModel
    {
        public List<XYZ.InventoryManagementSystem.Framework.Product> Products { get; set; }
    }
}
