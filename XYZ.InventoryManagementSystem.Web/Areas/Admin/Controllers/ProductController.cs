using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZ.InventoryManagementSystem.Framework;
using XYZ.InventoryManagementSystem.Framework.MidTable;
using XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Product;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly FrameworkContext _context;

        public ProductController(FrameworkContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           var products = _context.Products
                .Include(b => b.Brand)
                .Include(c => c.Category)
                .Include(c => c.ProductColor)
                    .ThenInclude(c => c.Color)
                .Include(s => s.ProductSizes)
                    .ThenInclude(s => s.Size)
                .Include(s => s.ProductStores)
                    .ThenInclude(s => s.Store)
                .ToList();

            var model = new ProductIndexViewModel
            {
                Products = products
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var productModel = new ProductAddViewModel
            {
                Brands = _context.Brands.ToList(),
                Categories = _context.Categories.ToList(),
                Colors = _context.Colors.ToList(),
                Sizes = _context.Sizes.ToList(),
                Stores = _context.Stores.ToList()
            };

            return View(productModel);
        }

        [HttpPost]
        public IActionResult Create(ProductAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var insertModel = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Qty = model.Qty,
                    Description = model.Description,
                    Available = model.Available,
                    BrandId = model.BrandId,
                    CategoryId = model.CategoryId
                };

                for(int i = 0; i< model.ColorIds.Count; i++)
                {
                    var productColor = new ProductColor
                    {
                        Product = insertModel,
                        ColorId = model.ColorIds[i]
                    };
                    _context.Add(productColor);
                }

                for (int i = 0; i < model.SizeIds.Count; i++)
                {
                    var productSizes = new ProductSize
                    {
                        Product = insertModel,
                        SizeId = model.SizeIds[i]
                    };
                    _context.Add(productSizes);
                }

                for (int i = 0; i < model.StoreIds.Count; i++)
                {
                    var productStore = new ProductStore
                    {
                        Product = insertModel,
                        StoreId = model.StoreIds[i]
                    };
                    _context.Add(productStore);
                }

                _context.Products.Add(insertModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            model.Brands = _context.Brands.ToList();
            model.Categories = _context.Categories.ToList();
            model.Colors = _context.Colors.ToList();
            model.Sizes = _context.Sizes.ToList();
            model.Stores = _context.Stores.ToList();

            return View(model);
        }
    }
}
