using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Services;
using System.Web.Mvc;

namespace Gerasite.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            this._service = service;
        }

        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult CadastrarUsuario()
        {
            return View();
        }
        public ActionResult PainelUsuario()
        {
            Usuario usuario = new Usuario
            {
                Nome = "Everton",
            };
            return View(usuario);
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.SaveOrUpdate(usuario);                   
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }
    }
}