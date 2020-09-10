using Microsoft.AspNetCore.Mvc;
using System.Linq;
using XYZ.InventoryManagementSystem.Framework;
using XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Order;
using XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.OrderViewModel;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly FrameworkContext _context;

        public OrderController(FrameworkContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allOrder = _context.Orders.ToList();

            var model = new OrderIndexViewModel
            {
                Orders = allOrder
            };
            return View(model);
        }

      [HttpGet]
       public IActionResult Create()
        {
            var companyDetails = _context.Companies.FirstOrDefault();
            var product = _context.Products.ToList();

            var createOrderViewModel = new OrderCreateViewModel
            {
               VatValue = (int)companyDetails.VatCharge,
               ProductsName = product
            };

            return View(createOrderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel vmModel)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    CustomerName = vmModel.Name,
                    Address = vmModel.Address,
                    Phone = vmModel.Phone,
                    ProductName = vmModel.ProductName,
                    Qty = vmModel.Qty.Value,
                    Rate = vmModel.Rate,
                    Amount = vmModel.Amount,
                    GrossAmount = vmModel.GrossAmount,
                    ServiceCharge = 0,
                    Vat = vmModel.Vat,
                    Discount = vmModel.Discount,
                    NetAmount = vmModel.NetAmount
                };

                _context.Orders.Add(order);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            vmModel.ProductsName = _context.Products.ToList();
            vmModel.VatValue = (int)_context.Companies.FirstOrDefault().VatCharge;
            return View(vmModel);
        }
    }
}
