using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Smp.NobleUI.Pages.TenantManagement.Tenants
{
    public class IndexModel : TenantManagementPageModel
    {
        public virtual Task<IActionResult> OnGetAsync()
        {
            return Task.FromResult<IActionResult>(Page());
        }

        public virtual Task<IActionResult> OnPostAsync()
        {
            return Task.FromResult<IActionResult>(Page());
        }
    }
}