using Gerasite.Application;
using Gerasite.Application.Services.Interfaces;
using Gerasite.Application.ViewModels.TemplateViewModels;
using Gerasite.Dominio.Entidades;
using Gerasite.Infra.Data.Context;
using Gerasite.Web.Utils;
using Microsoft.AspNet.Identity;
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
        public TemplateController(ITemplateService template, ITemplateArquivadoService templateArquivado) { 
            this._template = template;
            this._templateArquivado = templateArquivado;
        }
        private GerasiteContext context = new GerasiteContext();
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
                context.Templates.Add(template);
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
                    context.SaveChanges();
                    return RedirectToAction("ListaTemplates", "Template");
                }
                catch
                {
                    return View(template);
                }

            }
            return View(template);
        }


        public ActionResult EditarTemplate(int id, string idUser)
        {
            var usuario = GerenciadorUsuario.FindByIdAsync(idUser);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            var temp = new TemplateArquivado();
            temp.Id = id;
            temp.IdUsuario = usuario.ToString();
            TemplateArquivado Arquivo = new TemplateArquivado { IdUsuario = usuario.ToString(), IdTemplate = temp.Id };
            return View(Arquivo);
        }

        [HttpPost]
        public ActionResult EditarTemplate(TemplateArquivado template)
        {
            if (ModelState.IsValid)
            {
                int temp = template.Id;
                var ID = User.Identity.GetUserId();
                TemplateArquivado Arquivo = new TemplateArquivado { IdUsuario = ID, IdTemplate = temp };
              
                switch (temp)
                {
                    case 1:
                        context.TemplatesArquivados.Add(Arquivo);
                        context.SaveChanges();
                        return RedirectToAction("Portfolio", "Template");
                    default:
                        context.TemplatesArquivados.Add(Arquivo);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Usuario");
                }
                
            }
            return View(template);
        }
        
        public ActionResult Portfolio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Portfolio(PortfolioViewModel model)
        {
            Session["Titulo"] = model.Titulo;
            Session["Profissao"] = model.Profissao;
            return View("PortfolioDetalhe");

        }

       public ActionResult PortfolioDetalhe()
        {
            
            return View();
        }

    }
}