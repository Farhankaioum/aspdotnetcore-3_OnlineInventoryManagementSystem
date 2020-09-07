using System;
using System.Collections.Generic;
using System.Text;

namespace XYZ.InventoryManagementSystem.Framework.MidTable
{
    public class ProductSize
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Size Size { get; set; }
        public int SizeId { get; set; }
    }
}
