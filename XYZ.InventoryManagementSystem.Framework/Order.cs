using System;
using System.Collections.Generic;
using System.Text;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal Vat { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
    }
}
