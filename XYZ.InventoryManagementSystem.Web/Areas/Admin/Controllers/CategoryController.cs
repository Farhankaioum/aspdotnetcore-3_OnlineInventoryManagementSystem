﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XYZ.InventoryManagementSystem.Framework;
using XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Category;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly FrameworkContext _context;

        public CategoryController(FrameworkContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var brands = _context.Categories.ToList();

            var model = new CategoryIndexViewModel();
            model.Categories = brands;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CategoryViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var brand = new Category
                {
                    Name = viewModel.Name,
                    Status = viewModel.Status
                };

                _context.Categories.Add(brand);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var existingBrand = _context.Categories.FirstOrDefault(b => b.Id == Id);

            var model = new CategoryViewModel
            {
                Id = existingBrand.Id,
                Name = existingBrand.Name,
                Status = existingBrand.Status
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingBrand = _context.Categories.FirstOrDefault(b => b.Id == viewModel.Id);
                existingBrand.Name = viewModel.Name;
                existingBrand.Status = viewModel.Status;


                _context.Categories.Update(existingBrand);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            var existingBrand = _context.Categories.FirstOrDefault(b => b.Id == Id);
            _context.Categories.Remove(existingBrand);
            var result = _context.SaveChanges();

            if (result > 0)
                return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
