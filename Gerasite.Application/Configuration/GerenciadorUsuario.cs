using Gerasite.Application.Context;
using Gerasite.Application.Models;
using IdentitySample.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;


namespace Gerasite.Application
{
    public class GerenciadorUsuario : UserManager<UsuarioIdentity>
    {
        public GerenciadorUsuario(IUserStore<UsuarioIdentity> store): base(store)
        {

        }
        public static GerenciadorUsuario Create(IdentityFactoryOptions<GerenciadorUsuario> options, IOwinContext context)
        {
            GerasiteIdentityDbContext db = context.Get<GerasiteIdentityDbContext>();
            GerenciadorUsuario manager = new GerenciadorUsuario(new UserStore<UsuarioIdentity>(db));

            manager.UserValidator = new UserValidator<UsuarioIdentity>(manager)
            {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames = false,
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };
            // Definindo a classe de serviço de e-mail
            manager.EmailService = new EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<UsuarioIdentity>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

    }
}
