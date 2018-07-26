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
            var user = new Usuario()
            {
                Id = 0,
                Nome = "teste",
                Email = "teste@teste.com",
                Senha = "123",
                HistoricoTemplate = false
            };

            _service.SaveOrUpdate(user);
            return View();
        }
    }
}