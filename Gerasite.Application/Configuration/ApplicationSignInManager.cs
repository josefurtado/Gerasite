using Gerasite.Application.Models;
using Microsoft.AspNet.Identity.Owin;

namespace Gerasite.Application.Configuration
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
    }
}
