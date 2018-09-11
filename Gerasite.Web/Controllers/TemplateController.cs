using Gerasite.Application;
using Gerasite.Application.Models;
using Gerasite.Application.Services.Interfaces;
using Gerasite.Dominio.Entidades;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace Gerasite.Web.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplateService _template;
        private readonly ITemplateArquivadoService _templateArquivado;
        public TemplateController(ITemplateService template, ITemplateArquivadoService templateArquivado) { 
            this._template = template;
            this._templateArquivado = templateArquivado;
        }

        public ActionResult ListaTemplates()
        {
            return View(_template.Get());
        }

        [Authorize(Roles = "Adm")]
        public ActionResult CriarTemplate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarTemplate(Template template)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _template.SaveOrUpdate(template);
                    return RedirectToAction("Index", "Usuario");
                }
                return View(template);
            }
            catch
            {
                return View(template);
            }
        }


        public ActionResult EditarTemplate(int id)
        {
            TemplateArquivado temp = _templateArquivado.Get(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        public ActionResult EditarTemplate()
        {
            return View();
        }

        
    }
}