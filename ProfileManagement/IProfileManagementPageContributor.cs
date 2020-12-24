using System.Threading.Tasks;

namespace Smp.NobleUI.ProfileManagement
{
    public interface IProfileManagementPageContributor
    {
        Task ConfigureAsync(ProfileManagementPageCreationContext context);
    }
}
