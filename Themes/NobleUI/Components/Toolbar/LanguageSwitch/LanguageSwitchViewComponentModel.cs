using System.Collections.Generic;
using Volo.Abp.Localization;

namespace Smp.NobleUI.Themes.NobleUI.Components.Toolbar.LanguageSwitch
{
    public class LanguageSwitchViewComponentModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public List<LanguageInfo> OtherLanguages { get; set; }
    }
}
