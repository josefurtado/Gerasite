using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Services;
using System.Web.Mvc;

namespace Gerasite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioService _service;

        public HomeController(IUsuarioService service)
        {
            this._service = service;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}