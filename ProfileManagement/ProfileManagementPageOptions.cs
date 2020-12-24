using System.Collections.Generic;

namespace Smp.NobleUI.ProfileManagement
{
    public class ProfileManagementPageOptions
    {
        public List<IProfileManagementPageContributor> Contributors { get; }

        public ProfileManagementPageOptions()
        {
            Contributors = new List<IProfileManagementPageContributor>();
        }
    }
}
