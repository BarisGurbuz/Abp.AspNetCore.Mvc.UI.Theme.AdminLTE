# Smp.NobleUI
ABP framework NobleUI Theme


ABP framework ile geliştirilen AspNet MVC / Razor projeleri için NobleUI temasıdır.

Öncelikle ABP CLI aracını aşağıdaki komutu kullanarak kuralım.

````shell
dotnet tool install -g Volo.Abp.Cli
````

Zaten yüklüyse aşağıdaki komutla güncelleyebilirsiniz:

````shell
dotnet tool update -g Volo.Abp.Cli
````

Temayı uygulamak için örnek yeni bir proje oluşturalım:

````shell
abp new AbpThemeNobleUI
````

Proje ana dizininde Tema projesi için **theme** isminde klasör oluşturalım ve komut satırında **theme** dizinine gidelim:

````shell
mkdir theme
cd theme
````

ABP için **NobleUI** tema modülü projesini git üzerinden alalım:

````shell
git clone https://github.com/mucahiddanis/Smp.NobleUI.git
````

Proje ana dizinine dönelim:

````shell
cd ..
cd ..
````

**sln** dosyasına NobleUI tema projesini ekleyelim:

````shell
dotnet sln add theme/Smp.NobleUI/Smp.NobleUI.csproj
````

`AbpThemeNobleUI.Web` projemize NobleUI tema projesini referans edelim:

````shell
<ProjectReference Include="..\..\theme\Smp.NobleUI\Smp.NobleUI.csproj" />
````

`AbpThemeNobleUI.Web.AbpThemeNobleUIWebModule.cs` web modülünde temamızı konfigüre edelim:

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

Yukarıdaki kodun altına aşağıdaki kodu ekleyelim:

````csharp
typeof(AbpAspNetCoreMvcUiNobleUIThemeModule),
````

modülün çözümlenmesi için **using** ekleyelim:

````csharp
using Smp.NobleUI;
````

**DependsOn** listesi son olarak şöyle olmalı:

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

NobleUI temasının css, js, image gibi kaynak dosyaları için **VirtualFileSystem** ayarını yapalım. Bunun için `AbpThemeNobleUI.Web.AbpThemeNobleUIWebModule.cs` dosyasında
`ConfigureVirtualFileSystem` methoduna ekleme yapalım:

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

Projeyi **Build** edelim.

`AbpThemeNobleUI.DbMigrator` projesini çalıştıralım.
`AbpThemeNobleUI.Web` Projesini çalıştıralım.

![login](screenshots/login.png)

![home](screenshots/home.png)

![user-management](screenshots/user-management.png)

![user-management-permissions](screenshots/user-management-permissions.png)

![account-manage](screenshots/account-manage.png)



**Versiyon Güncelleme**

Aktif versiyon

> ABP v3.2.0

`Smp.NobleUI.csproj` tema proje dosyasında ABP paketlerinin versiyonlarını güncellemeniz yeterli.

![theme-abp-package-references](screenshots/theme-abp-package-references.png)