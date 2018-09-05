using Gerasite.Application.ViewModels;
using Gerasite.Application.Services.Interfaces;
using System.Web.Mvc;
using Gerasite.Infra.Data.Context;
using System.Linq;
using Gerasite.Dominio.Entidades;

namespace Gerasite.Web.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            this._service = service;
        }
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult EditarUsuario(int id)
        {
            UsuarioViewModel usuario = _service.Get(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditarUsuario(UsuarioViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.SaveOrUpdate(usuario);
                    return RedirectToAction("Index", "Usuario");
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