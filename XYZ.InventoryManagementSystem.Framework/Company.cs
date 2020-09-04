using System.ComponentModel.DataAnnotations;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal ChargeAmount { get; set; } = 0;

        public decimal VatCharge { get; set; } = 0;

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Message { get; set; }

        public string Currentcy { get; set; }

    }
}
