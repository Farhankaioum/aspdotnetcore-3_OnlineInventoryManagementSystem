using System.Collections.Generic;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.OrderViewModel
{
    public class OrderIndexViewModel : AdminBaseModel
    {
        public List<XYZ.InventoryManagementSystem.Framework.Order> Orders { get; set; }
    }
}
