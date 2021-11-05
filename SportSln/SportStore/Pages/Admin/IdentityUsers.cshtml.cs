using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace SportStore.Pages.Admin
{
    public class IdentityUsersModel : PageModel
    {
        private UserManager<IdentityUser> userManager;

        public IdentityUser AdminUser { get; set; }

        public IdentityUsersModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            AdminUser = await userManager.FindByNameAsync("Admin");
        }
    }
}
