using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XYZ.InventoryManagementSystem.Framework;

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
            return View(_context.Stores.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Store());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                _context.Stores.Add(store);
                _context.SaveChanges();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _context.Stores.ToList())});
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", store)});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var existingStore = _context.Stores.FirstOrDefault(s => s.Id == id);

            return View(existingStore);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                var existingStore = _context.Stores.FirstOrDefault(s => s.Id == store.Id);
                existingStore.Name = store.Name;
                existingStore.Status = store.Status;

                _context.Stores.Update(existingStore);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
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
