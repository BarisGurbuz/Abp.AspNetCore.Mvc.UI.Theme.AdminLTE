using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Identity.Web.Pages.Identity;

namespace Smp.NobleUI.Identity.Roles
{
    public class IndexModel : IdentityPageModel
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