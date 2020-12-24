using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Smp.NobleUI.Themes.NobleUI.Components.ControlSidebar
{
    public class ControlSidebarViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/NobleUI/Components/ControlSidebar/Default.cshtml");
        }
    }
}
