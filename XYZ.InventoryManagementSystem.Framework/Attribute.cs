using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Attribute
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
