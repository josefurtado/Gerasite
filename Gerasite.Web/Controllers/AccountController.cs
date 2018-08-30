using Gerasite.Application.Models;
using Gerasite.Application.ViewModels.AccountViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using Gerasite.Application;

namespace Gerasite.Web.Controllers
{
    public class AccountController : Controller
    {
        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioIdentity user = new UsuarioIdentity { UserName = model.Nome, Email = model.Email };
                if (model.Senha == model.ConfirmaSenha)
                {
                    IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
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
