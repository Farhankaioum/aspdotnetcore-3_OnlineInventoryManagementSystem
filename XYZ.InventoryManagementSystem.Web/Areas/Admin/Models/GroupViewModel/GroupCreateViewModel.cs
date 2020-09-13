using System.ComponentModel.DataAnnotations;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.GroupViewModel
{
    public class GroupCreateViewModel : AdminBaseModel
    {
        [Required]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
