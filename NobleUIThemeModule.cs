using Smp.NobleUI.Bundling;
using Smp.NobleUI.Localization;
using Smp.NobleUI.Pages.Account;
using Smp.NobleUI.ProfileManagement;
using Smp.NobleUI.Toolbars;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Smp.NobleUI
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
        )]
    public class NobleUIThemeModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(NobleUIThemeModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<NobleUITheme>();

                // 应用主体风格
                options.DefaultThemeName = NobleUITheme.Name;
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<NobleUIThemeModule>("Smp.NobleUI");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<NobleUIResource>("en")
                    .AddVirtualJson("/Localization/NobleUI");
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new NobleUIThemeMainTopToolbarContributor());
            });

            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/index");
            });


            ConfigureProfileManagementPage();

            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(NobleUIThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Styles.Global)
                            .AddContributors(typeof(NobleUIThemeGlobalStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(NobleUIThemeBundles.Scripts.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(StandardBundles.Scripts.Global)
                            .AddContributors(typeof(NobleUIThemeGlobalScriptContributor));
                    });
            });
        }

        private void ConfigureProfileManagementPage()
        {
            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/Account/Manage");
            });

            Configure<ProfileManagementPageOptions>(options =>
            {
                options.Contributors.Add(new AccountProfileManagementPageContributor());
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options.ScriptBundles
                    .Configure(typeof(ManageModel).FullName,
                        configuration =>
                        {
                            configuration.AddFiles("/Pages/Account/Components/ProfileManagementGroup/Password/Default.js");
                            configuration.AddFiles("/Pages/Account/Components/ProfileManagementGroup/PersonalInfo/Default.js");
                        });
            });

        }
    }
}
