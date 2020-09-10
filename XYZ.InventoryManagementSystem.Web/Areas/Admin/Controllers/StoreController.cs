using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XYZ.InventoryManagementSystem.Framework;
using XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.StoreViewModel;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        private readonly FrameworkContext _context;

        public StoreController(FrameworkContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allStores = _context.Stores.ToList();
            var model = new StoreIndexViewModel
            {
                Stores = allStores
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new StoreViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                _context.Stores.Add(store);
                _context.SaveChanges();

                var allStores = _context.Stores.ToList();
                var model = new StoreIndexViewModel
                {
                    Stores = allStores
                };

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", model) });
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", store)});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var existingStore = _context.Stores.FirstOrDefault(s => s.Id == id);

            var model = new StoreViewModel
            {
                Id = existingStore.Id,
                Name = existingStore.Name,
                Status = existingStore.Status
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StoreViewModel vmStore)
        {
            if (ModelState.IsValid)
            {
                var existingStore = _context.Stores.FirstOrDefault(s => s.Id == vmStore.Id);
                existingStore.Name = vmStore.Name;
                existingStore.Status = vmStore.Status;

                _context.Stores.Update(existingStore);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(vmStore);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var existingStore = _context.Stores.FirstOrDefault(s => s.Id == id);

            if(existingStore != null)
            {
                _context.Remove(existingStore);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
