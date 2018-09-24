using Gerasite.Application;
using Gerasite.Application.Services.Interfaces;
using Gerasite.Application.Services.Interfaces.ITemplatesService;
using Gerasite.Dominio.Entidades;
using Gerasite.Infra.Data.Context;
using Gerasite.Web.Utils;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace Gerasite.Web.Controllers
{
    public class TemplateController : Controller
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

        private readonly ITemplateService _template;
        private readonly ITemplateArquivadoService _templateArquivado;
        private readonly GerasiteContext context = new GerasiteContext();

        public TemplateController(ITemplateService template, ITemplateArquivadoService templateArquivado) { 
            this._template = template;
            this._templateArquivado = templateArquivado;
        }
        
        public ActionResult ListaTemplates()
        {
            return View(context.Templates);
        }

        //[Authorize(Roles = "Adm")]
        public ActionResult CriarTemplate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarTemplate(Template template)
        {
            if (ModelState.IsValid)
            {             
                try
                {
                    if (template.Foto != null)
                    {
                        var pic = Utilidades.UploadPhoto(template.Foto);
                        if (!string.IsNullOrEmpty(pic))
                        {
                            template.FOTO_ENDERECO = string.Format("~/Images/Fotos/{0}", pic);
                        }
                    }
                    _template.SaveOrUpdate(template);
                    return RedirectToAction("ListaTemplates", "Template");
                }
                catch
                {
                    return View(template);
                }

            }
            return View(template);
        }

        [Authorize]
        public ActionResult EditarTemplate(int id)
        {
            Template template = _template.Get(id);
            if (template == null)
            {
                return HttpNotFound();
            }
            switch (template.Id)
            {
                case 1:
                    return RedirectToAction("Portfolio", "Portfolio");
                case 2:
                    return RedirectToAction("Comercial", "Comercial");
                case 3:
                    return RedirectToAction("Mostruario", "Mostruario");
                default:
                    return RedirectToAction("Index", "Usuario");
            }
        }
        
        [Authorize]
        public ActionResult VerDetalhe(int id)
        {
            TemplateArquivado template = _templateArquivado.Get(id);
            if (template == null)
            {
                return HttpNotFound();
            }
            switch (template.IdTipoTemplate)
            {
                case 1:
                    return RedirectToAction("PortfolioDetalhe"  +'/'+ template.IdTemplate, "Portfolio"  );
                case 2:
                    return RedirectToAction("ComercialDetalhe" + '/' + template.IdTemplate, "Comercial");
                case 3:
                    return RedirectToAction("MostruarioDetalhe" + '/' + template.IdTemplate, "Mostruario");
                default:
                    return RedirectToAction("Index", "Usuario");
            }
        }
      


    }
}