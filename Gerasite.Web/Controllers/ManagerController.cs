using Gerasite.Application;
using Gerasite.Application.Models;
using Gerasite.Application.ViewModels.ManagerViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gerasite.Web.Controllers
{
    [Authorize]
    public class ManagerController : Controller
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

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        #endregion

        [Authorize]
        public ActionResult EditUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioIdentity usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            var edit = new EditUserViewModel();
            edit.Nome = usuario.UserName;
            edit.Email = usuario.Email;
            return View(edit);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditUser(EditUserViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                UsuarioIdentity usuario = GerenciadorUsuario.FindById(editUser.Id);
                usuario.UserName = editUser.Nome;
                usuario.Email = editUser.Email;
                IdentityResult result = GerenciadorUsuario.Update(usuario);
                if (result.Succeeded)
                {
                    TempData["Message"] = "Informações desta conta foram editadas, realize login novamente e sincronize com nossa base de dados.";
                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(editUser);
        }

        [Authorize]
        public ActionResult EditPassword(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioIdentity usuario = GerenciadorUsuario.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            var edit = new EditPasswordViewModel();
            return View(edit);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditPassword(EditPasswordViewModel editPassword)
        {
            if (ModelState.IsValid)
            {
                UsuarioIdentity usuario = GerenciadorUsuario.FindById(editPassword.Id);
                usuario.PasswordHash = GerenciadorUsuario.PasswordHasher.HashPassword(editPassword.Senha);

                if (editPassword.Senha == editPassword.ConfirmaSenha)
                {
                    IdentityResult result = GerenciadorUsuario.Update(usuario);
                    if (result.Succeeded)
                    {
                        TempData["Message"] = "Informações desta conta foram editadas, realize login novamente e sincronize com nossa base de dados.";
                        return RedirectToAction("Index", "Usuario");
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

            return View(editPassword);
        }
    }
}