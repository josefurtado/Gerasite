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
                        var code = await GerenciadorUsuario.GenerateEmailConfirmationTokenAsync(user.Id);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        await GerenciadorUsuario.SendEmailAsync(user.Id, "Confirme sua Conta", "Por favor confirme sua conta clicando neste link: <a href='" + callbackUrl + "'></a>");
                        ViewBag.Link = callbackUrl;
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
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await GerenciadorUsuario.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
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
