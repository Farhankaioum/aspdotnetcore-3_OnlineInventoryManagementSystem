using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Dynamic.Core;
using XYZ.InventoryManagementSystem.Framework;
using System.Linq;
using XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Company;
using System.Threading.Tasks;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly FrameworkContext _context;

        public CompanyController(FrameworkContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var existingCompanyValue = _context.Companies.FirstOrDefault(a => a.Id == id.Value);

            if (existingCompanyValue == null)
                return NotFound();

            var viewModel = new CompanyEditViewModel
            {
                Id = existingCompanyValue.Id,
                Name = existingCompanyValue.Name,
                ChargeAmount = existingCompanyValue.ChargeAmount,
                VatCharge = existingCompanyValue.VatCharge,
                Address = existingCompanyValue.Address,
                Phone = existingCompanyValue.Phone,
                Country = existingCompanyValue.Country,
                Message = existingCompanyValue.Message,
                Currency = existingCompanyValue.Currentcy
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CompanyEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingInfoOfCompany = _context.Companies.FirstOrDefault(c => c.Id == model.Id);

                if (existingInfoOfCompany == null)
                    return NotFound();

                existingInfoOfCompany.Name = model.Name;
                existingInfoOfCompany.ChargeAmount = model.ChargeAmount;
                existingInfoOfCompany.VatCharge = model.VatCharge;
                existingInfoOfCompany.Address = model.Address;
                existingInfoOfCompany.Phone = model.Phone;
                existingInfoOfCompany.Country = model.Country;
                existingInfoOfCompany.Message = model.Message;
                existingInfoOfCompany.Currentcy = model.Currency;

                await _context.SaveChangesAsync();

                return View(new CompanyEditViewModel());
            }

            return View(model);
        }


    }
}
