using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Smp.NobleUI
{
    [ThemeName(Name)]
    public class NobleUITheme : ITheme, ITransientDependency
    {
        public const string Name = "NobleUI";

        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/NobleUI/Layouts/Application.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/NobleUI/Layouts/Account.cshtml";
                case StandardLayouts.Empty:
                    return "~/Themes/NobleUI/Layouts/Empty.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/NobleUI/Layouts/Application.cshtml" : null;
            }
        }
    }
}
