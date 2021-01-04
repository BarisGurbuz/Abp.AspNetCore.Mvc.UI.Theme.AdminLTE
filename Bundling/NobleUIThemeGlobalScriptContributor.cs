using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Smp.NobleUI.Bundling
{
    public class NobleUIThemeGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            ////context.Files.Clear();
            //// || t.Contains("/libs/datatables.net")
            //context.Files.RemoveAll(t => t.Contains("/libs/jquery/") || t.Contains("/libs/bootstrap/"));

            //context.Files.Insert(1, "/plugins/jquery/jquery.min.js");

            //context.Files.Insert(3, "/plugins/bootstrap/js/bootstrap.js");
            context.Files.Add("/themes/NobleUI/vendors/core/core.js");
            context.Files.Add("/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js");
            context.Files.Add("/themes/NobleUI/vendors/jquery.flot/jquery.flot.js");
            context.Files.Add("/themes/NobleUI/vendors/jquery.flot/jquery.flot.resize.js");
            context.Files.Add("/themes/NobleUI/vendors/bootstrap-datepicker/bootstrap-datepicker.js");
            context.Files.Add("/themes/NobleUI/vendors/feather-icons/feather.min.js");
            context.Files.Add("/themes/NobleUI/js/template.js");
            //context.Files.Add("/themes/NobleUI/vendors/.js");
            //context.Files.Add("/themes/NobleUI/js/layout.js");
        }
    }
}
