using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZ.InventoryManagementSystem.Framework;
using XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Brand;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly FrameworkContext _context;

        public BrandController(FrameworkContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var brands = _context.Brands.AsNoTracking().ToList();

            var model = new BrandIndexViewModel();
            model.Brands = brands;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new BrandViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BrandViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand { 
                    Name = viewModel.Name,
                    Status = viewModel.Status
                };

                _context.Brands.Add(brand);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var existingBrand = _context.Brands.FirstOrDefault(b => b.Id == Id);

            var model = new BrandViewModel
            {
                Id = existingBrand.Id,
                Name = existingBrand.Name,
                Status = existingBrand.Status
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BrandViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingBrand = _context.Brands.FirstOrDefault(b => b.Id == viewModel.Id);
                existingBrand.Name = viewModel.Name;
                existingBrand.Status = viewModel.Status;


                _context.Brands.Update(existingBrand);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            var existingBrand = _context.Brands.FirstOrDefault(b => b.Id == Id);
            _context.Brands.Remove(existingBrand);
            var result = _context.SaveChanges();

            if (result > 0)
                return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
