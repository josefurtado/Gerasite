using Gerasite.Application;
using Gerasite.Application.Services.Interfaces;
using Gerasite.Application.Services.Interfaces.ITemplatesService;
using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Web.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace Gerasite.Web.Controllers.TemplatesControllers
{
    public class ComercialController : Controller
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
        private readonly IComercialService _comercialService;

        public ComercialController(ITemplateArquivadoService templateArquivado, IComercialService comercialService)
        {
            this._templateArquivado = templateArquivado;
            this._comercialService = comercialService;
        }


        [Authorize]
        public ActionResult Comercial()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Comercial(Comercial model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (model.ArquivoImg1 != null && model.ArquivoImg2 != null && model.ArquivoImg2 != null)
                    {
                        var pic = Utilidades.UploadPhoto(model.ArquivoImg1);
                        var pic2 = Utilidades.UploadPhoto(model.ArquivoImg2);
                        var pic3 = Utilidades.UploadPhoto(model.ArquivoImg3);
                        if (!string.IsNullOrEmpty(pic) && !string.IsNullOrEmpty(pic2))
                        {
                            model.CapaImg1 = string.Format("~/Images/Fotos/{0}", pic);
                            model.Img2 = string.Format("~/Images/Fotos/{0}", pic2);
                            model.Img3 = string.Format("~/Images/Fotos/{0}", pic3);
                        }
                    }
                    _comercialService.SaveOrUpdate(model);
                    var ID = User.Identity.GetUserId();
                    TemplateArquivado arquivado = new TemplateArquivado { IdUsuario = ID, IdTemplate = model.Id, IdTipoTemplate = 2, Imagem = model.CapaImg1 };
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
        public ActionResult ComercialDetalhe(int id)
        {
            Comercial template = _comercialService.Get(id);
            if (template == null)
            {
                return HttpNotFound();
            }
            return View(template);
        }
    }
}