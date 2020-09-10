using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.InventoryManagementSystem.Framework;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.StoreViewModel
{
    public class StoreIndexViewModel : AdminBaseModel
    {
        public List<Store> Stores { get; set; }
    }
}
