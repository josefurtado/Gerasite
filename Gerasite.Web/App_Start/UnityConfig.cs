using Gerasite.Application.Services;
using Gerasite.Application.Services.Interfaces;
using Gerasite.Application.Services.Interfaces.ITemplatesService;
using Gerasite.Application.Services.TemplatesService;
using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Entidades.Templates;
using Gerasite.Infra.Data.Context;
using Gerasite.Infra.Data.Transaction;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace Gerasite.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<GerasiteContext, GerasiteContext>();
            container.RegisterType<Usuario, Usuario>();
            container.RegisterType<IUnityOfWork, UnityOfWork>();
            container.RegisterType<IUsuarioService, UsuarioService>();
            container.RegisterType<Template, Template>();
            container.RegisterType<ITemplateService, TemplateService>();
            container.RegisterType<TemplateArquivado, TemplateArquivado>();
            container.RegisterType<ITemplateArquivadoService, TemplateArquivadoService>();
            container.RegisterType<Portfolio, Portfolio>();
            container.RegisterType<IPortfolioService, PortfolioService>();
            container.RegisterType<Comercial, Comercial>();
            container.RegisterType<IComercialService, ComercialService>();
            container.RegisterType<Mostruario, Mostruario>();
            container.RegisterType<IMostruarioService, MostruarioService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}