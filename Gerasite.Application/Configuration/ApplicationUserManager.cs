using Gerasite.Application.Models;
using Microsoft.AspNet.Identity;

namespace Gerasite.Application.Configuration
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
    }
}
