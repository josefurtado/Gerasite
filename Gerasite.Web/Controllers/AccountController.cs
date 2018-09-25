using Gerasite.Application.Models;
using Gerasite.Application.ViewModels.AccountViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;
using Gerasite.Application;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System;

namespace Gerasite.Web.Controllers
{
    
    public class AccountController : Controller
    {
        #region Helpers

        private GerenciadorUsuario _gerenciadorUsuario;
        public GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
            private set => _gerenciadorUsuario = value;
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion

        [AllowAnonymous]
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
                var user = new UsuarioIdentity { UserName = model.Nome, Email = model.Email, EmailConfirmed = true };
                var resulte = await GerenciadorUsuario.CreateAsync(user, model.Senha);
                if (model.Senha == model.ConfirmaSenha)
                {                  
                    if (resulte.Succeeded)
                    {
                        AuthManager.SignOut();
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


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var findEmail = GerenciadorUsuario.FindByEmail(model.Email);
                var user = GerenciadorUsuario.Find(findEmail.UserName, model.Senha);
                if (user == null)
                {
                    ModelState.AddModelError("", "Email	ou senha inválido(s).");
                }
                else
                {
                    ClaimsIdentity ident = GerenciadorUsuario.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties{IsPersistent = false }, ident);
                    if(returnUrl == null)
                    {
                        returnUrl = "/Home";
                    }
                    return RedirectToAction("Index", "Usuario");
                }
             }
             return View(model);
        }


        public ActionResult Logout()
        {
            AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await GerenciadorUsuario.FindByEmailAsync(model.Email);
                if (user == null || !(await GerenciadorUsuario.IsEmailConfirmedAsync(user.Id)))
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    var code = await GerenciadorUsuario.GeneratePasswordResetTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await GerenciadorUsuario.SendEmailAsync(user.Id, "Esqueci a senha", "Por favor altere sua senha clicando aqui: " + callbackUrl);
                    return View("ForgotPasswordConfirmation");
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GerenciadorUsuario.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View();
            }
            var result = await GerenciadorUsuario.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrorsFromResult(result);
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
