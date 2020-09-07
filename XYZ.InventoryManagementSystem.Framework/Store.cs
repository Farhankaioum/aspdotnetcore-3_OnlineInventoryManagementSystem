﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Status { get; set; }

    }
}
