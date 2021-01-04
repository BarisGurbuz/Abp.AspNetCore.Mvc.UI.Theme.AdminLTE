using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation;

namespace Smp.NobleUI.Pages.TenantManagement.Tenants
{
    public class EditModalModel : TenantManagementPageModel
    {
        [BindProperty]
        public TenantInfoModel Tenant { get; set; }

        protected ITenantAppService TenantAppService { get; }

        public EditModalModel(ITenantAppService tenantAppService)
        {
            TenantAppService = tenantAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync(Guid id)
        {
            Tenant = ObjectMapper.Map<TenantDto, TenantInfoModel>(
                await TenantAppService.GetAsync(id)
            );

            return Page();
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<TenantInfoModel, TenantUpdateDto>(Tenant);
            await TenantAppService.UpdateAsync(Tenant.Id, input);

            return NoContent();
        }

        public class TenantInfoModel : ExtensibleObject
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [Required]
            [DynamicStringLength(typeof(TenantConsts), nameof(TenantConsts.MaxNameLength))]
            [Display(Name = "DisplayName:TenantName")]
            public string Name { get; set; }
        }
    }
}