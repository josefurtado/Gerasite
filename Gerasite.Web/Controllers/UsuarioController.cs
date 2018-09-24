using Gerasite.Infra.Data.Context;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Gerasite.Web.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {     
        public UsuarioController()
        {
        }

        private readonly GerasiteContext context = new GerasiteContext();

        [Authorize]
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            
            return View(context.TemplatesArquivados.Where(u => u.IdUsuario.Equals(user)));
        }


        
    }
}