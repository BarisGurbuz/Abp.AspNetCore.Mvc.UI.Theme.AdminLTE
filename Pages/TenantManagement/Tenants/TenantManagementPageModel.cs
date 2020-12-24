using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.TenantManagement.Web;

namespace Smp.NobleUI.Pages.TenantManagement.Tenants
{
    public abstract class TenantManagementPageModel : AbpPageModel
    {
        public TenantManagementPageModel()
        {
            ObjectMapperContext = typeof(AbpTenantManagementWebModule);
        }
    }
}