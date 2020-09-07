using System.Collections.Generic;
using XYZ.InventoryManagementSystem.Framework.MidTable;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductSize> ProductSizes { get; set; }
    }
}
