using Gerasite.Application;
using Gerasite.Application.Services.Interfaces;
using Gerasite.Application.Services.Interfaces.ITemplatesService;
using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Infra.Data.Context;
using Gerasite.Web.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gerasite.Web.Controllers.TemplatesControllers
{
    [Authorize]
    public class PortfolioController : Controller
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
        private readonly ITemplateArquivadoService _templateArquivado;
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(ITemplateArquivadoService templateArquivado, IPortfolioService portfolioService)
        {
            this._templateArquivado = templateArquivado;
            this._portfolioService = portfolioService;
        }

        [Authorize]
        public ActionResult Portfolio()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Portfolio(Portfolio model)
        {
                if (ModelState.IsValid)
                {
                  
                    try
                    {
                        if (model.ArquivoImg1 != null && model.ArquivoImg2 != null)
                        {
                            var pic = Utilidades.UploadPhoto(model.ArquivoImg1);
                            var pic2 = Utilidades.UploadPhoto(model.ArquivoImg2);
                            if (!string.IsNullOrEmpty(pic) && !string.IsNullOrEmpty(pic2))
                            {
                                model.CaminhoImg1 = string.Format("~/Images/Fotos/{0}", pic);
                                model.CaminhoImg2 = string.Format("~/Images/Fotos/{0}", pic2);
                            }
                        }
                    _portfolioService.SaveOrUpdate(model);
                        var ID = User.Identity.GetUserId();
                        TemplateArquivado arquivado = new TemplateArquivado { IdUsuario = ID, IdTemplate = model.Id, IdTipoTemplate = 1, Imagem = model.CaminhoImg1};
                        _templateArquivado.SaveOrUpdate(arquivado);
                        return RedirectToAction("Index", "Usuario");
                    }
                    catch
                    {
                        return View(model);
                    }
                }
          

            return View();
        }

        [Authorize]
        public ActionResult PortfolioDetalhe(int id)
        {
            Portfolio template = _portfolioService.Get(id);
            if (template == null)
            {
                return HttpNotFound();
            }
            return View(template);
        }              
    }
}