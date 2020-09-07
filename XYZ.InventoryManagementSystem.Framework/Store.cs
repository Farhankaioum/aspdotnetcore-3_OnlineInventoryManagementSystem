using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XYZ.InventoryManagementSystem.Framework.MidTable;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public List<ProductStore> ProductStores { get; set; }
    }
}
