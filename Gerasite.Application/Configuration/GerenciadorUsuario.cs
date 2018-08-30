using Gerasite.Application.Context;
using Gerasite.Application.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Gerasite.Application
{
    public class GerenciadorUsuario : UserManager<UsuarioIdentity>
    {
        public GerenciadorUsuario(IUserStore<UsuarioIdentity> store): base(store)
        {

        }
        public static GerenciadorUsuario Create(IdentityFactoryOptions<GerenciadorUsuario> options,IOwinContext context)
        {
            GerasiteIdentityDbContext db = context.Get<GerasiteIdentityDbContext>();
            GerenciadorUsuario manager = new GerenciadorUsuario(new UserStore<UsuarioIdentity>(db));
            return manager;
        }

    }
}
