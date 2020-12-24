using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Smp.NobleUI.Themes.NobleUI.Components.Footer
{
    public class FooterViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/NobleUI/Components/Footer/Default.cshtml");
        }
    }
}
