using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XYZ.InventoryManagementSystem.Web.Areas.Admin.Models.Accounts
{
    public class AccountIndexPageModel : AdminBaseModel
    {
        public List<IdentityUser> Users { get; set; }
    }
}
