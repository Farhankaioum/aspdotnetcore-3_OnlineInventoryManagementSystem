using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Product
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
        
        public int Qty { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }
    }
}
