using System.Collections.Generic;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Category
{
    public class CategoryIndexViewModel : AdminBaseModel
    {
        public List<XYZ.InventoryManagementSystem.Framework.Category> Categories { get; set; }
    }
}
