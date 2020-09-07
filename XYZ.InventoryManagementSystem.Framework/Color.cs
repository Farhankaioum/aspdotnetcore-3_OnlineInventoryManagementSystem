using System.Collections.Generic;
using XYZ.InventoryManagementSystem.Framework.MidTable;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductColor> ProductColor { get; set; }
    }
}
