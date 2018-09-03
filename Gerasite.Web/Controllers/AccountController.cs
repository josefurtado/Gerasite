using Gerasite.Application.Models;
using Gerasite.Application.ViewModels.AccountViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using Gerasite.Application;
using System.Threading.Tasks;

namespace Gerasite.Web.Controllers
{
    public class AccountController : Controller
    {
        private GerenciadorUsuario _gerenciadorUsuario;
        public GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
            private set => _gerenciadorUsuario = value;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UsuarioIdentity { UserName = model.Email, Email = model.Email };
                var resulte = await GerenciadorUsuario.CreateAsync(user, model.Senha);
                if (model.Senha == model.ConfirmaSenha)
                {                  
                    if (resulte.Succeeded)
                    {
                        await GerenciadorUsuario.SendEmailAsync(user.Id, "Boas Vindas", "Obrigado por fazer parte desta equipe");
                        return View("DisplayEmail");
                        
                    }
                    else
                   {
                        AddErrorsFromResult(resulte);
                   }
                }
                else
                {
                    ModelState.AddModelError("", "Senhas não correspondem.");
                }
            }
            return View(model);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
