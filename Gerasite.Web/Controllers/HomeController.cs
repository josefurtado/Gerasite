using System.Web.Mvc;

namespace Gerasite.Web.Controllers
{
    public class HomeController : Controller
    {    
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}