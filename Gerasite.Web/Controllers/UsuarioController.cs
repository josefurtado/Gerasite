<<<<<<< HEAD
﻿using Gerasite.Application.ViewModels;
using Gerasite.Application.Services.Interfaces;
using System.Web.Mvc;
using Gerasite.Infra.Data.Context;
using System.Linq;
using Gerasite.Dominio.Entidades;
=======
﻿using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Services;
using System.Web.Mvc;
>>>>>>> Master_Copy

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

        [HttpPost]
        public ActionResult CadastrarUsuario(UsuarioViewModel usuario)
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
<<<<<<< HEAD

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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario user)
        {
            if (ModelState.IsValid)
            {
                using (GerasiteContext varBanco = new GerasiteContext())
                {
                    var usuario = varBanco.Usuarios.Where(u => u.Nome.Equals(user.Nome) && u.Senha.Equals(user.Senha)).FirstOrDefault();
                    if (usuario != null)
                    {
                        Session["Nome"] = usuario.Nome;
                        Session["Id"] = usuario.Id;
                        return RedirectToAction("Index", "Usuario");
                    }
                    if (usuario == null)
                    {
                        Session["Message"] = "Dados Incorretos!";
                    }
                }
            }
            return View(user);
        }
=======
>>>>>>> Master_Copy
    }
}