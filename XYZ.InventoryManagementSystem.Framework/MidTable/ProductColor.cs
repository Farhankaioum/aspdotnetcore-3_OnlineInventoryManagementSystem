using System;
using System.Collections.Generic;
using System.Text;

namespace XYZ.InventoryManagementSystem.Framework.MidTable
{
    public class ProductColor
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
