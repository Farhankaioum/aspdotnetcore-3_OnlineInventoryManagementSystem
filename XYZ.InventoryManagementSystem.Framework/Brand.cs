using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public List<Product> Products { get; set; }
    }
}
