using System.Collections.Generic;
using XYZ.InventoryManagementSystem.Framework;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.GroupViewModel
{
    public class GroupIndexViewModel : AdminBaseModel
    {
        public List<Group> Groups { get; set; }
    }
}
