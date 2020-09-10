using Microsoft.AspNetCore.Mvc;
using XYZ.InventoryManagementSystem.Web.Areas.Admin.Models;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardModel();
            return View(model);
        }
    }
}
