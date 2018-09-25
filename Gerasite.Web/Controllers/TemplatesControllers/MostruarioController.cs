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
    public class MostruarioController : Controller
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
        private readonly IMostruarioService _mostruarioService;

        public MostruarioController(ITemplateArquivadoService templateArquivado, IMostruarioService mostruarioService)
        {
            this._templateArquivado = templateArquivado;
            this._mostruarioService = mostruarioService;
        }

        [Authorize]
        public ActionResult Mostruario()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Mostruario(Mostruario model)
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
                        var pic4 = Utilidades.UploadPhoto(model.ArquivoImg4);
                        var pic5 = Utilidades.UploadPhoto(model.ArquivoImg5);
                        var pic6 = Utilidades.UploadPhoto(model.ArquivoImg6);
                        var pic7 = Utilidades.UploadPhoto(model.ArquivoImg7);
                        var pic8 = Utilidades.UploadPhoto(model.ArquivoImg8);
                        var pic9 = Utilidades.UploadPhoto(model.ArquivoImg9);
                        if (!string.IsNullOrEmpty(pic) && !string.IsNullOrEmpty(pic2) && !string.IsNullOrEmpty(pic3) 
                            && !string.IsNullOrEmpty(pic4) && !string.IsNullOrEmpty(pic5) && !string.IsNullOrEmpty(pic6) 
                            && !string.IsNullOrEmpty(pic7) && !string.IsNullOrEmpty(pic8) && !string.IsNullOrEmpty(pic9))
                        {
                            model.Img1 = string.Format("~/Images/Fotos/{0}", pic);
                            model.Img2 = string.Format("~/Images/Fotos/{0}", pic2);
                            model.Img3 = string.Format("~/Images/Fotos/{0}", pic3);
                            model.Img4 = string.Format("~/Images/Fotos/{0}", pic4);
                            model.Img5 = string.Format("~/Images/Fotos/{0}", pic5);
                            model.Img6 = string.Format("~/Images/Fotos/{0}", pic6);
                            model.Img7 = string.Format("~/Images/Fotos/{0}", pic7);
                            model.Img8 = string.Format("~/Images/Fotos/{0}", pic8);
                            model.Img9 = string.Format("~/Images/Fotos/{0}", pic9);
                        }
                    }
                    _mostruarioService.SaveOrUpdate(model);
                    var IdUser = User.Identity.GetUserId();
                    TemplateArquivado templateArquivado = new TemplateArquivado { IdUsuario = IdUser, IdTemplate = model.Id, IdTipoTemplate = 3, Imagem = model.Img1 };
                    _templateArquivado.SaveOrUpdate(templateArquivado);
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
        public ActionResult MostruarioDetalhe(int id)
        {
            Mostruario templateMostruario = _mostruarioService.Get(id);
            if (templateMostruario == null)
            {
                return HttpNotFound();
            }
            return View(templateMostruario);
        }
    }
}