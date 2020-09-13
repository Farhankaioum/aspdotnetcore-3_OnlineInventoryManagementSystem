using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XYZ.InventoryManagementSystem.Framework;
using XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.GroupViewModel;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
        private readonly FrameworkContext _context;

        public GroupController(FrameworkContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var groups = _context.Groups.ToList();

            var model = new GroupIndexViewModel
            {
                Groups = groups
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new GroupCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GroupCreateViewModel vmModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Group
                {
                    Name = vmModel.Name,
                    Status = vmModel.Status
                };
                model.Since = DateTime.Now;

                _context.Groups.Add(model);
                _context.SaveChanges();

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", vmModel) });
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", vmModel) });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var existingGroup = _context.Groups.FirstOrDefault(g => g.Id == id);

            if (existingGroup == null)
            {
                return NotFound();
            }

            var model = new GroupEditViewModel
            {
                Id = existingGroup.Id,
                Name = existingGroup.Name,
                Status = existingGroup.Status
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GroupEditViewModel vmModel)
        {
            if (ModelState.IsValid)
            {
                var existingModel = _context.Groups.FirstOrDefault(g => g.Id == vmModel.Id);
                existingModel.Name = vmModel.Name;
                existingModel.Status = vmModel.Status;

                _context.SaveChanges();

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", vmModel) });
            }

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Edit", vmModel) });
        }

        // Delete group
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var existingGroup = _context.Groups.FirstOrDefault(g => g.Id == id);

            if (existingGroup == null)
                return NotFound();

            _context.Groups.Remove(existingGroup);
            _context.SaveChanges();

            return RedirectToAction("Index", "Group");
        }
    }
}
