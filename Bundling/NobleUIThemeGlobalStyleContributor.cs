using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Smp.NobleUI.Bundling
{
    public class NobleUIThemeGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            // 移除默认的style
            //context.Files.Clear();

            ////context.Files.RemoveAll(t => t.Contains("/libs/@fortawesome/") || t.Contains("/libs/bootstrap/"));

            //context.Files.Add("/libs/abp/core/abp.css");
            ////context.Files.Insert(1, "/libs/bootstrap/css/bootstrap.min.css");
            ////context.Files.Insert(2, "/libs/font-awesome/css/font-awesome.css");
            //context.Files.Add("/plugins/fontawesome-free/css/all.min.css");
            context.Files.Add("/libs/Ionicons/css/ionicons.min.css");
            context.Files.Add("/plugins/overlayScrollbars/css/OverlayScrollbars.min.css");
            context.Files.Add("/themes/NobleUI/css/NobleUI.min.css");
            //context.Files.Add("/themes/NobleUI/css/skins/_all-skins.css");
            context.Files.Add("/themes/NobleUI/css/layout.css");
        }
    }
}
