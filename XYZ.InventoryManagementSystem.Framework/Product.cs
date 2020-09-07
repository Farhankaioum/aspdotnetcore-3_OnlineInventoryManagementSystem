using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using XYZ.InventoryManagementSystem.Framework.MidTable;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Product
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
        
        public int Qty { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public Brand Brand { get; set; }
        public int BrandId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public List<ProductColor> ProductColor { get; set; }

        public List<ProductSize> ProductSizes { get; set; }

        public List<ProductStore> ProductStores { get; set; }

    }
}
