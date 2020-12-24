
# Using the NobleUI Theme with the ABP Framework MVC / Razor Pages UI

This article shows step by step how to use the NobleUI Theme for ABP Framework MVC / Razor Page UI applications.

First, let's install the ABP CLI tool using the command below.

````shell
dotnet tool install -g Volo.Abp.Cli
````

If it's already installed, you can update it with the following command:

````shell
dotnet tool update -g Volo.Abp.Cli
````

Let's create a sample new project to apply the theme:

````shell
abp new AbpThemeNobleUI
````

Let's create a **theme** folder for the theme project in the project main directory and go to the **theme** directory on the command line:

````shell
mkdir theme
cd theme
````

Let's get the **NobleUI** theme module project for ABP via git:

````shell
git clone https://github.com/mucahiddanis/Smp.NobleUI.git
````

Go back to the project main directory:

````shell
cd ..
cd ..
````

Let's add the NobleUI theme project to the **sln** file:

````shell
dotnet sln add theme/Smp.NobleUI/Smp.NobleUI.csproj
````

Let's reference the NobleUI theme project in our `AbpThemeNobleUI.Web` project:

````shell
<ProjectReference Include="..\..\theme\Smp.NobleUI\Smp.NobleUI.csproj" />
````

Configure our theme in the `AbpThemeNobleUI.Web.AbpThemeNobleUIWebModule.cs` web module:

````csharp
[DependsOn(
        typeof(AbpThemeNobleUIHttpApiModule),
        typeof(AbpThemeNobleUIApplicationModule),
        typeof(AbpThemeNobleUIEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule)
        )]
    public class AbpThemeNobleUIWebModule : AbpModule
````


````csharp
typeof(AbpAspNetCoreMvcUiBasicThemeModule),
````

Let's add the following code below the code above:

````csharp
typeof(AbpAspNetCoreMvcUiNobleUIThemeModule),
````

Add **using** to reference theme project

````csharp
using Smp.NobleUI;
````

The **DependsOn** list should finally be:

````csharp
[DependsOn(
        typeof(AbpThemeNobleUIHttpApiModule),
        typeof(AbpThemeNobleUIApplicationModule),
        typeof(AbpThemeNobleUIEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreMvcUiNobleUIThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule)
        )]
    public class AbpThemeNobleUIWebModule : AbpModule
````

Let's set **VirtualFileSystem** for the source files of NobleUI theme such as css, js, image. For this, `AbpThemeNobleUI.Web.AbpThemeNobleUIWebModule.cs` in the file. Let's add to the `ConfigureVirtualFileSystem` method:

````chasrp
private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpThemeNobleUIDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}AbpThemeNobleUI.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpThemeNobleUIDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}AbpThemeNobleUI.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpThemeNobleUIApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}AbpThemeNobleUI.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpThemeNobleUIApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}AbpThemeNobleUI.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpThemeNobleUIWebModule>(hostingEnvironment.ContentRootPath);

                    // NobleUI teması
                    options.FileSets.ReplaceEmbeddedByPhysical<AbpThemeNobleUIApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Smp.NobleUI"));
                });
            }
        }
````

Let's **Build** the project.

Let's run the `AbpThemeNobleUI.DbMigrator` and `AbpThemeNobleUI.Web` project.

![login](screenshots/login.png)

![home](screenshots/home.png)

![user-management](screenshots/user-management.png)

![user-management-permissions](screenshots/user-management-permissions.png)

![account-manage](screenshots/account-manage.png)




**Version Update**

Active version

> ABP v3.2.0

You just need to update the versions of ABP packages in the theme project file `Smp.NobleUI.csproj`.

![theme-abp-package-references](screenshots/theme-abp-package-references.png)
