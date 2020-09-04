using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XYZ.InventoryManagementSystem.Framework;
using Attribute = XYZ.InventoryManagementSystem.Framework.Attribute;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttributesController : Controller
    {
        private readonly FrameworkContext _context;

        public AttributesController(FrameworkContext context)
        {
            _context = context;
        }

        // GET: Admin/Attributes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attributes.ToListAsync());
        }

      public async Task<IActionResult> AddOrEditAsync(int id=0)
      {
            if (id == 0)
                return View(new Attribute());
            else
            {
                var model = await _context.Attributes.FindAsync(id);

                if (model == null)
                    return NotFound();

                return View(model);
            }
      }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Status")] Attribute attribute)
        {
            if (ModelState.IsValid)
            {
                if(attribute.Id == 0)
                {
                    _context.Add(attribute);
                }
                else
                {
                    _context.Update(attribute);
                }
                
                await _context.SaveChangesAsync();

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _context.Attributes.ToList()) });
            }

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "AddOrEdit", attribute) });
        }

        // GET: Admin/Attributes/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] Attribute attribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attribute);
        }

        // GET: Admin/Attributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }
            return View(attribute);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status")] Attribute attribute)
        {
            if (id != attribute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeExists(attribute.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(attribute);
        }

        // GET: Admin/Attributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        // POST: Admin/Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attribute = await _context.Attributes.FindAsync(id);
            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeExists(int id)
        {
            return _context.Attributes.Any(e => e.Id == id);
        }
    }
}
