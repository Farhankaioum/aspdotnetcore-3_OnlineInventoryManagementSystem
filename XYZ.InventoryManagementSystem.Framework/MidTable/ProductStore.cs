using System;
using System.Collections.Generic;
using System.Text;

namespace XYZ.InventoryManagementSystem.Framework.MidTable
{
    public class ProductStore
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Store Store { get; set; }
        public int StoreId { get; set; }
    }
}
